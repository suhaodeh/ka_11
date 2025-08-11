using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace KASHOP.PL.Utils
{
    public class EmailSetting : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sosoodeh07@gmail.com", "eile lxlj xarr ockz")
            };

            return client.SendMailAsync(
                new MailMessage(from: "sosoodeh07@gmail.com",
                                to: email,
                                subject,
                                htmlMessage
                                )
                { IsBodyHtml=true});
        
    }
    }
}
