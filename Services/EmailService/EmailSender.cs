using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Services.EmailService
{
   public class EmailSender : IEmailSender
    {
        public async Task SendMessage(string emailTo, string messageBody, string messageSubject)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGrid");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("karina2002goba@gmail.com", "Karina");
            var subject = messageSubject;
            var to = new EmailAddress(emailTo, "Name");
            var plainTextContent = $"Email-розсилка";
            var htmlContent = messageBody ;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }
}
