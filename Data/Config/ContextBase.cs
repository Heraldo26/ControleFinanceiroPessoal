using Microsoft.EntityFrameworkCore;
using Model.FluxoCaixa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Config
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FluxoCaixaViewModel>().HasKey(m => m.Id);
            builder.Entity<FluxoCaixaViewModel>().Property(f => f.Id).ValueGeneratedOnAdd();
            base.OnModelCreating(builder);
        }

        public DbSet<FluxoCaixaViewModel> fluxoCaixas { get; set; }

    }
}
