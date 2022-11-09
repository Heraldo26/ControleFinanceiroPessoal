using ControleFinanceiro.Models.FluxoCaixa;
using Model.FluxoCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Helpers
{
    public class ConverterToModel
    {
        public static IEnumerable<FluxoCaixaModel> ConverterFluxoCaixa(IEnumerable<FluxoCaixaViewModel> viewModel)
        {
            List<FluxoCaixaModel> fluxoCaixa = new List<FluxoCaixaModel>();

            foreach (var item in viewModel)
            {
                fluxoCaixa.Add(new FluxoCaixaModel
                {
                    Id = item.Id,
                    Tipo = item.Tipo,
                    Data = item.Data,
                    Descricao = item.Descricao,
                    Valor = item.Valor,
                });
            }

            return fluxoCaixa;
        }

        public static FluxoCaixaViewModel ConverterViewModelCaixa(FluxoCaixaModel model)
        {
            FluxoCaixaViewModel viewModel = new FluxoCaixaViewModel();
            viewModel.Id = model.Id;
            viewModel.Tipo = model.Tipo;
            viewModel.Data = model.Data;
            viewModel.Descricao = model.Descricao;
            viewModel.Valor = model.Valor;

            return viewModel;
        }
    }
}
