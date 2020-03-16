using Dort.Service;
using Dort.ServiceImpl.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dort.ServiceImpl
{
    public sealed class MailService : IMailService
    {
        private readonly IConfiguration _configs;

        public MailService(IConfiguration configs)
        {
            _configs = configs;
        }

        public async Task SendAsync(string to, string content, string subject)
        {
            try
            {
                string dortEmail = _configs.GetSection("EmailInfo:Email").Value;
                string dortPassword = _configs.GetSection("EmailInfo:Password").Value;
                string smtpAdress = _configs.GetSection("EmailInfo:SMTPAdress").Value;
                int port = int.Parse(_configs.GetSection("EmailInfo:Port").Value);

                using SmtpClient smtp = new SmtpClient()
                {
                    Host = smtpAdress,
                    Port = port,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(dortEmail, dortPassword)
                };

                using MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(dortEmail),
                    IsBodyHtml = true,
                    Body = content,
                    Subject = subject,
                    BodyEncoding = Encoding.UTF8,
                    SubjectEncoding = Encoding.UTF8
                };

                mail.To.Add(new MailAddress(to));

                await smtp.SendMailAsync(mail);
            }
            catch (Exception e)
            {
                throw new EmailSendingFailureException("Fail in send email", e);
            }
        }
    }
}
