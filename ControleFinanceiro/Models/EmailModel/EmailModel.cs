using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models.EmailModel
{
    public class EmailModel
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class EmailConfiguration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string EmailFromAddress { get; set; }
        public string SmtpAddress { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
    }
}
