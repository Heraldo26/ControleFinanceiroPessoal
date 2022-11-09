using ControleFinanceiro.Models.EmailModel;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ControleFinanceiro.Infra.Services
{
    public class MailService : IMailService
    {
        private string smtpAddress = "smtp-mail.outlook.com";
        private int portNumber = 587;
        private string emailFromAddress = "fluxocaixapessoal@hotmail.com";
        private string password = "linx@2022";

        //private readonly EmailConfiguration _emailConfiguration;

        //public MailService(IOptions<EmailConfiguration> emailConfiguration)
        //{
        //    _emailConfiguration = emailConfiguration.Value;
        //}        

        public void SendMail(EmailModel email, bool isHtml = false)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(emailFromAddress);
                mailMessage.Body = email.Body;
                mailMessage.Subject = email.Subject;
                mailMessage.IsBodyHtml = isHtml;
                mailMessage.Priority = MailPriority.Normal;
                mailMessage.To.Add(email.Email);

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.Send(mailMessage);
                }
            }
        }
    }
}
