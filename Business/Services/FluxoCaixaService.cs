using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositories;
using Model.FluxoCaixa;

namespace Business.Services
{
    public class FluxoCaixaService : IFluxoCaixaService
    {
        private readonly IFluxoCaixaRepository _caixaRepository;
        public FluxoCaixaService(IFluxoCaixaRepository caixaRepository)
        {
            _caixaRepository = caixaRepository;
        }
        public bool Create(FluxoCaixaViewModel fluxoCaixa)
        {
            return _caixaRepository.Create(fluxoCaixa);
        }

        public List<DateTime> DatasNegativa()
        {
            return _caixaRepository.DatasNegativa();
        }

        public IEnumerable<FluxoCaixaViewModel> Get()
        {
            return _caixaRepository.Get();
        }

        public decimal SaldoFinal()
        {
            return _caixaRepository.SaldoFinal();
        }

        public Dictionary<int, decimal> Saldos()
        {
            return _caixaRepository.Saldos();
        }
    }
}
