
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DotNetEnv;
using FluentValidation;
using FluentValidation.AspNetCore;
using JobBoardWebApi.Data;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using JobBoardWebApi.Service;
using JobBoardWebApi.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Org.BouncyCastle.Crypto.Signers;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
Env.Load(); // Load .env

builder.Configuration.AddEnvironmentVariables();


var cloudName = Environment.GetEnvironmentVariable("Cloudinary__CloudName");
var apiKey = Environment.GetEnvironmentVariable("Cloudinary__ApiKey");
var apiSecret = Environment.GetEnvironmentVariable("Cloudinary__ApiSecret");
var connection = Environment.GetEnvironmentVariable("DB_CONNECTION");
var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
var expiresMinutes = Environment.GetEnvironmentVariable("JWT_EXPIRES_MINUTES");


Account account = new Account(cloudName, apiKey, apiSecret);
Cloudinary cloudinary = new Cloudinary(account);
cloudinary.Api.Secure = true;

// Initial connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection));

// initial logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .ReadFrom.Configuration(builder.Configuration)   // đọc appsettings.json
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
    .CreateLogger();

builder.Host.UseSerilog();

// cấu hình password cho user
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+";
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddRoles<IdentityRole>() // add roles
    .AddRoleManager<RoleManager<IdentityRole>>() //  make use of RoleManager
    .AddUserManager<UserManager<User>>() // make use of UserManager to create user
    .AddSignInManager<SignInManager<User>>() // make user of Sign in manager
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add authentication
builder.Services
    .AddAuthentication(config =>
    {
        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
     // add bearer
     .AddJwtBearer(option =>
     {
         option.SaveToken = true;
         option.RequireHttpsMetadata = false;
         option.TokenValidationParameters = new TokenValidationParameters()
         {
             //validate the token based on the key we have provided inside the appsettings.json JWT:Secret
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = issuer,
             ValidAudience = audience,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret.ToString()))
         };
     });


// DI

builder.Services.AddSingleton(cloudinary);
builder.Services.AddScoped<ICandidateRepo, CandidateService>();
builder.Services.AddScoped<ILevelRepo, LevelService>();
builder.Services.AddScoped<ICompanyRepo, CompanyService>();
builder.Services.AddScoped<ISkillRepo, SkillService>();
builder.Services.AddScoped<IRecruiterRepo, RecruiterRepo>();
builder.Services.AddScoped<IJobRepo, JobService>();
builder.Services.AddScoped<IApplicationRepo, ApplicationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IPhotoService, PhotoService>();
builder.Services.AddScoped<IJwtService, JWTService>();

// Register Validators
builder.Services.AddFluentValidationAutoValidation(); // Bật tự động validate
builder.Services.AddValidatorsFromAssemblyContaining<ValidationApplicationRequest>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Config Swagger able to add bearer token
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

// Config serilog
builder.Host.UseSerilog((ctx, config) =>
{
    config.WriteTo.Console().MinimumLevel.Information();
    config.WriteTo.File(
       path: AppDomain.CurrentDomain.BaseDirectory + "/logs/log-.txt",
       rollingInterval: RollingInterval.Day,
       rollOnFileSizeLimit: true,
       formatter: new JsonFormatter()).MinimumLevel.Information();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging(opts =>
{
    opts.MessageTemplate = "HTTP {RequestMethod} {RequestPath} => {StatusCode} in {Elapsed:0.0000} ms";
});


app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
