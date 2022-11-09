using Model.FluxoCaixa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IFluxoCaixaRepository
    {
        bool Create(FluxoCaixaViewModel fluxoCaixa);
        IEnumerable<FluxoCaixaViewModel> Get();
        decimal SaldoFinal();
        Dictionary<int, decimal> Saldos();
        List<DateTime> DatasNegativa();
    }
}
