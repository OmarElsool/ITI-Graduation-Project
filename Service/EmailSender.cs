using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace Airbnb.Service
{
    public class EmailSender : IEmailSender
    {
        public  async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromMail = "omarelsool17@gmail.com";
            var fromPassword = "omarelsool123123";

            var message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(email);
            message.Body = $"<html><body>{htmlMessage}</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
                UseDefaultCredentials = true,
            };
            smtpClient.Send(message);
        }
    }
}
