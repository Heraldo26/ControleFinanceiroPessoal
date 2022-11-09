using AutoMapper;
using ControleFinanceiro.Models.FluxoCaixa;
using Model.FluxoCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FluxoCaixaModel, FluxoCaixaViewModel>();
        }
    }
}
