
using ControleFinanceiro.Models.EmailModel;

namespace ControleFinanceiro.Infra.Services
{
    public interface IMailService
    {
        void SendMail(EmailModel email, bool isHtml = false);
    }
}
