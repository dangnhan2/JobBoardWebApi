
using DotNetEnv;
using CloudinaryDotNet;
using JobBoardWebApi.Models;
using JobBoardWebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Env.Load(); // Load .env

builder.Configuration.AddEnvironmentVariables();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));

var cloudName = Environment.GetEnvironmentVariable("Cloudinary__CloudName");
var apiKey = Environment.GetEnvironmentVariable("Cloudinary__ApiKey");
var apiSecret = Environment.GetEnvironmentVariable("Cloudinary__ApiSecret");
var connection = Environment.GetEnvironmentVariable("DB_CONNECTION");

Account account = new Account(cloudName, apiKey, apiSecret);
Cloudinary cloudinary = new Cloudinary(account);
cloudinary.Api.Secure = true;


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection));

// Add services to the container.
// ??ng ký Cloudinary service
builder.Services.AddSingleton(cloudinary);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
