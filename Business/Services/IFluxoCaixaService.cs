using Model.FluxoCaixa;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public interface IFluxoCaixaService
    {
        IEnumerable<FluxoCaixaViewModel> Get();
        bool Create(FluxoCaixaViewModel fluxoCaixa);
        decimal SaldoFinal();
        Dictionary<int, decimal> Saldos();
        List<DateTime> DatasNegativa();
    }
}
