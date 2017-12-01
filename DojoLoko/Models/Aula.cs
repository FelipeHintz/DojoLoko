using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DojoLoko.Models
{

    public class Aula
    {
        public int ID { get; set; }
        public IEnumerable<Aluno> Alunos { get; set; }
        [Required]
        [Range(1, 99)]
        public IEnumerable<int> AlunosId { get; set; }
        public DateTime data { get; set; }
    }
}