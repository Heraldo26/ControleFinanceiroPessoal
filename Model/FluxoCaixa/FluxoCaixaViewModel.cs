using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.FluxoCaixa
{
    [Table("TB_FLUXO_CAIXA")]
    public class FluxoCaixaViewModel
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("TIPO")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Column("DATA")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Column("DESCRICAO")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Column("VALOR")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
    }
}
