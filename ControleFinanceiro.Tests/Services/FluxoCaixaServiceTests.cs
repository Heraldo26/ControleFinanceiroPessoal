using Business.Services;
using Business.Util;
using Data.Repositories;
using Model.FluxoCaixa;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ControleFinanceiro.Tests.Services
{
    public class FluxoCaixaServiceTests
    {
        private FluxoCaixaService _fluxoCaixaService;
        public FluxoCaixaServiceTests()
        {
            _fluxoCaixaService = new FluxoCaixaService(new Mock<IFluxoCaixaRepository>().Object);
        }

        [Fact]
        public void ValidCreateFluxoCaixa()
        {
            FluxoCaixaViewModel fluxoCaixaModel = new FluxoCaixaViewModel
            {
                Tipo = TipoCaixaEnum.Despesa.ToString(),
                Data = Convert.ToDateTime("08/10/2022"),
                Descricao = "Compra de Notbooks",
                Valor = (decimal)670.70,
            };

            var result = _fluxoCaixaService.Create(fluxoCaixaModel);

            //var exception = Assert.Throws<Exception>(() => _fluxoCaixaService.Create(fluxoCaixaModel));
            //Assert.Equal("Error ao salvar dados", exception.Message);
            Assert.True(result);
        }

        [Fact]
        public void DatasNegativa_GetDatas()
        {
            List<DateTime> datas = new List<DateTime>();
            datas = _fluxoCaixaService.DatasNegativa();

            foreach (var data in datas)
            {
                Assert.IsType<DateTime>(data);
            }
        }

        [Fact]
        public void ValidListFluxoCaixa_GetList()
        {
            IEnumerable<FluxoCaixaViewModel> fluxoCaixas = new List<FluxoCaixaViewModel>();
            fluxoCaixas = _fluxoCaixaService.Get();

            Assert.IsType<FluxoCaixaViewModel>(fluxoCaixas);

            foreach (var item in fluxoCaixas)
            {
                Assert.IsType<int>(item.Id);
                Assert.IsType<string>(item.Tipo);
                Assert.IsType<DateTime>(item.Data);
                Assert.IsType<string>(item.Descricao);
                Assert.IsType<decimal>(item.Valor);
            }
        }

        [Fact]
        public void ValidSaldoFinal_ReturnDecimal()
        {
            var saldoFinal = _fluxoCaixaService.SaldoFinal();

            Assert.IsType<decimal>(saldoFinal);
        }
    }
}
