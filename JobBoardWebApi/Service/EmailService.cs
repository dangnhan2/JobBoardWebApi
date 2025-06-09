using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MimeKit;


namespace JobBoardWebApi.Service
{
    public interface IEmailService
    {
        public Task SendEmailToCandidateAsync(string recipientAddress, string subject, string body, string senderName, string senderEmail);
        public Task SendEmailAsync(string recipientAddress, string subject, string body);
    }
    public class EmailService : IEmailService
    {
        public async Task SendEmailToCandidateAsync(string recipientAddress, string subject, string body, string senderName, string senderEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress($"{senderName}", $"{senderEmail}"));
            message.To.Add(new MailboxAddress("", recipientAddress));
            message.Subject = subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.server.com", 587, false);
                await client.AuthenticateAsync("your@email.com", "yourpassword");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }

        public async Task SendEmailAsync(string recipientAddress, string subject, string body)
        {
            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress($"SukaBlyat", $"{senderEmail}"));
            //message.To.Add(new MailboxAddress("", recipientAddress));
            //message.Subject = subject;
            //message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            //{
            //    Text = body
            //};

            //using (var client = new SmtpClient())
            //{
            //    await client.ConnectAsync("smtp.server.com", 587, false);
            //    await client.AuthenticateAsync("your@email.com", "yourpassword");
            //    await client.SendAsync(message);
            //    await client.DisconnectAsync(true);
            //}
        }

    }
}
