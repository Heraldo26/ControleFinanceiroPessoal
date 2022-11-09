using System;
using System.Collections.Generic;
using Business.Services;
using Business.Util;
using ControleFinanceiro.Helpers;
using ControleFinanceiro.Models.FluxoCaixa;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    public class FluxoCaixaController : Controller
    {
        private IFluxoCaixaService _fluxoCaixa;

        public FluxoCaixaController(IFluxoCaixaService fluxoCaixa)
        {
            _fluxoCaixa = fluxoCaixa;
        }

        [HttpGet]
        public IActionResult ListaFluxoCaixa()
        {
            IEnumerable<FluxoCaixaModel> model = ConverterToModel.ConverterFluxoCaixa(_fluxoCaixa.Get());
            ViewBag.SaldoFinal = _fluxoCaixa.SaldoFinal();
            ViewBag.DatasNegativa = _fluxoCaixa.DatasNegativa();
            ViewBag.Saldos = _fluxoCaixa.Saldos();

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateFluxo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFluxo(FluxoCaixaModel model)
        {
            model.Tipo = Enum.GetName(typeof(TipoCaixaEnum), Convert.ToInt16(model.Tipo));

            if (!TryValidateModel(model, nameof(model)))
            {
                return View(model);
            }

            var viewModel = ConverterToModel.ConverterViewModelCaixa(model);

            _fluxoCaixa.Create(viewModel);

            return RedirectToAction("ListaFluxoCaixa");
        }

    }
}