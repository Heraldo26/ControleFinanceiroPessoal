using ControleFinanceiro.Infra.Services;
using ControleFinanceiro.Models.EmailModel;
using Data.Config;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace ControleFinanceiro.App_Start
{
    public class MonitoraSaldoCaixa
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public MonitoraSaldoCaixa(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void TarefaLoop()
        {
            ThreadStart tsTarefa = new ThreadStart(ThreadSaldo);
            Thread MinhaTarefa = new Thread(tsTarefa);
            MinhaTarefa.Start();
        }

        public void ThreadSaldo()
        {
            while (true)
            {
                GetSaldo();
                Thread.Sleep(TimeSpan.FromDays(1));
            }
        }

        public void GetSaldo()
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetService<ContextBase>();
                    FluxoCaixaRepository _fluxoCaixa = new FluxoCaixaRepository(dbContext);
                    decimal saldoFinal = _fluxoCaixa.SaldoFinal();

                    if (saldoFinal < 0)
                    {
                        EmailModel email = new EmailModel()
                        {
                            Email = "fluxocaixapessoal@hotmail.com",
                            Subject = "Saldo de Caixa negativo",
                            Body = $"O fluxo de Caixa está com Saldo Negativo de: R$ {saldoFinal}",
                        };
                        
                        MailService emailSend = new MailService();
                        emailSend.SendMail(email);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
