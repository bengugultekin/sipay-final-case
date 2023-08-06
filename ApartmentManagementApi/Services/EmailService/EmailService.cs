using ApartmentManagementApi.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace ApartmentManagementApi.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void SendEmail(EmailDto request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_configuration["Email:EmailUserName"]));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        using var smtp = new SmtpClient();
        smtp.Connect(_configuration["Email:EmailHost"], 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(_configuration["Email:EmailUserName"], _configuration["Email:EmailPassword"]);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
