using Business.Util;
using Data.Config;
using Model.FluxoCaixa;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class FluxoCaixaRepository : IFluxoCaixaRepository
    {
        private readonly ContextBase _context;

        public FluxoCaixaRepository(ContextBase context)
        {
            _context = context;
        }

        public bool Create(FluxoCaixaViewModel fluxoCaixa)
        {
            try
            {
                _context.fluxoCaixas.Add(fluxoCaixa);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ao salvar dados");
            }
        }

        public IEnumerable<FluxoCaixaViewModel> Get()
        {
            return _context.fluxoCaixas.OrderBy(o => o.Data).ToList();
        }

        public decimal SaldoFinal()
        {
            try
            {
                var saldoPositivo = _context.fluxoCaixas.Where(q => q.Tipo == TipoCaixaEnum.Receita.ToString()).Sum(s => s.Valor);
                var saldoNegativo = _context.fluxoCaixas.Where(q => q.Tipo == TipoCaixaEnum.Despesa.ToString()).Sum(s => s.Valor);
                var saldoFinal = saldoPositivo - saldoNegativo;
                return saldoFinal;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public Dictionary<int, decimal> Saldos()
        {
            try
            {
                Dictionary<int, decimal> saldos = new Dictionary<int, decimal>();
                IEnumerable<FluxoCaixaViewModel> caixa = Get();

                decimal saldo = 0;
                int tipo = 1;

                foreach (var item in caixa)
                {
                    if (item.Tipo == TipoCaixaEnum.Receita.ToString())
                        tipo = 1;
                    else if (item.Tipo == TipoCaixaEnum.Despesa.ToString())
                        tipo = -1;

                    saldo += item.Valor * tipo;
                    saldos.Add(item.Id, saldo);
                }

                return saldos;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public List<DateTime> DatasNegativa()
        {
            try
            {
                List<DateTime> dataNegativo = new List<DateTime>();
                IEnumerable<FluxoCaixaViewModel> caixa = Get();
                decimal saldo = 0;
                decimal despesa = 0;

                foreach (var item in caixa)
                {
                    if (item.Tipo == TipoCaixaEnum.Receita.ToString())
                        saldo += item.Valor;
                    else if (item.Tipo == TipoCaixaEnum.Despesa.ToString())
                        despesa += item.Valor;

                    if (despesa > saldo)
                        dataNegativo.Add(item.Data);
                }

                return dataNegativo.Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
