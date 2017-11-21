 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DojoLoko.Models
{

    [Table("dbo.Alunos")] 

    public class Aluno
    {
        public int ID { get; set; }
        public Faixa Faixa { get; set; }
        public int FaixaId { get; set; }
        public TipoDeAssociacao TipoDeAssociacao { get; set; }
        public int TipodeAssociacaoId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}