using System;
using System.Collections.Generic;
using AutoMapper;
using Business.Services;
using ControleFinanceiro.Infra.Services;
using ControleFinanceiro.Models.EmailModel;
using Data.Config;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContextBase>(opt => opt.UseInMemoryDatabase("ControleFinanceiroPessoal"));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<EmailConfiguration>(Configuration.GetSection("EmailConfiguration"));

            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IFluxoCaixaService, FluxoCaixaService>();
            services.AddScoped<IFluxoCaixaRepository, FluxoCaixaRepository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, IServiceScopeFactory serviceScopeFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var context = serviceProvider.GetService<ContextBase>();
            AdicionarDadosFluxoCaixa(context);
            new App_Start.MonitoraSaldoCaixa(serviceScopeFactory).TarefaLoop();

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=FluxoCaixa}/{action=ListaFluxoCaixa}/{id?}");
            });
        }
        
        private static void AdicionarDadosFluxoCaixa(ContextBase context)
        {
            var fluxos = new List<Model.FluxoCaixa.FluxoCaixaViewModel>()
            {
                new Model.FluxoCaixa.FluxoCaixaViewModel {
                    Id = 9999991,
                    Tipo = "Despesa",
                    Data = Convert.ToDateTime("29/08/2022"),
                    Descricao = "Cartão de Crédito",
                    Valor = Convert.ToDecimal(825.82),
                },
                new Model.FluxoCaixa.FluxoCaixaViewModel {
                    Id = 9999992,
                    Tipo = "Despesa",
                    Data = Convert.ToDateTime("29/08/2022"),
                    Descricao = "Curso C#",
                    Valor = Convert.ToDecimal(200.00),
                },
                new Model.FluxoCaixa.FluxoCaixaViewModel {
                    Id = 9999993,
                    Tipo = "Receita",
                    Data = Convert.ToDateTime("31/08/2022"),
                    Descricao = "Salário",
                    Valor = Convert.ToDecimal(7000.00),
                },
                new Model.FluxoCaixa.FluxoCaixaViewModel {
                    Id = 9999994,
                    Tipo = "Despesa",
                    Data = Convert.ToDateTime("01/09/2022"),
                    Descricao = "Mercado",
                    Valor = Convert.ToDecimal(3000.00),
                },
                new Model.FluxoCaixa.FluxoCaixaViewModel {
                    Id = 9999995,
                    Tipo = "Despesa",
                    Data = Convert.ToDateTime("01/09/2022"),
                    Descricao = "Farmácia",
                    Valor = Convert.ToDecimal(300.00),
                },
                new Model.FluxoCaixa.FluxoCaixaViewModel {
                    Id = 9999996,
                    Tipo = "Despesa",
                    Data = Convert.ToDateTime("01/09/2022"),
                    Descricao = "Combustível",
                    Valor = Convert.ToDecimal(800.25),
                },
                new Model.FluxoCaixa.FluxoCaixaViewModel {
                    Id = 9999997,
                    Tipo = "Despesa",
                    Data = Convert.ToDateTime("15/09/2022"),
                    Descricao = " Financiamento Carro",
                    Valor = Convert.ToDecimal(900.00),
                },
                new Model.FluxoCaixa.FluxoCaixaViewModel {
                    Id = 9999998,
                    Tipo = "Despesa",
                    Data = Convert.ToDateTime("22/09/2022"),
                    Descricao = " Financiamento Casa",
                    Valor = Convert.ToDecimal(1200.00),
                },
                new Model.FluxoCaixa.FluxoCaixaViewModel {
                    Id = 9999999,
                    Tipo = "Receita",
                    Data = Convert.ToDateTime("25/09/2022"),
                    Descricao = "Freelance Projeto XPTO",
                    Valor = Convert.ToDecimal(2500.00),
                },
            };

            context.fluxoCaixas.AddRange(fluxos);
            context.SaveChanges();
        }
    }
}
