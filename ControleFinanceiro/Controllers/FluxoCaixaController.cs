using System;
using System.Collections.Generic;
using AutoMapper;
using Business.Services;
using Business.Util;
using ControleFinanceiro.Models.FluxoCaixa;
using Microsoft.AspNetCore.Mvc;
using Model.FluxoCaixa;

namespace ControleFinanceiro.Controllers
{
    public class FluxoCaixaController : Controller
    {
        private IFluxoCaixaService _fluxoCaixa;
        private readonly IMapper _mapper;

        public FluxoCaixaController(IFluxoCaixaService fluxoCaixa, IMapper mapper)
        {
            _fluxoCaixa = fluxoCaixa;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListaFluxoCaixa()
        {
            IEnumerable<FluxoCaixaModel> model = _mapper.Map<List<FluxoCaixaModel>>(_fluxoCaixa.Get());
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

            var viewModel = _mapper.Map<FluxoCaixaViewModel>(model);

            _fluxoCaixa.Create(viewModel);

            return RedirectToAction("ListaFluxoCaixa");
        }

    }
}