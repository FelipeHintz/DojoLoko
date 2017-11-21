 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DojoLoko.Models
{

    public class Aluno
    {
        public int ID { get; set; }
        public Faixa Faixa { get; set; }
        [Required]
        [Range(1,99)]
        public int FaixaId { get; set; }
        public TipoDeAssociacao TipoDeAssociacao { get; set; }
        [Required]
        [Range(1, 99)]
        public int TipodeAssociacaoId { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }
    }
}