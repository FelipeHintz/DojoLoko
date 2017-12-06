using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DojoLoko.Models
{

    public class Aula
    {
        public Aula()
        {
            this.Alunos = new HashSet<Aluno>();
        }
        public int ID { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
        public ICollection<int> AlunosId { get; set; }
        public DateTime Data { get; set; }
    }
}