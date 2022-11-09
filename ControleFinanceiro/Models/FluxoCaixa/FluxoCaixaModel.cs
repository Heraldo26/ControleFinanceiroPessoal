using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models.FluxoCaixa
{
    public class FluxoCaixaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Id { get; set; }

        [DisplayName("Tipo")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Tipo { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Data { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(5, ErrorMessage = "O campo {0} não pode ser menor {1} caracteres.")]
        public string Descricao { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1, Double.PositiveInfinity)]
        public decimal Valor { get; set; }
    }
}
