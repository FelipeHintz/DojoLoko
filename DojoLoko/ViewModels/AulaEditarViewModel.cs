using DojoLoko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoLoko.ViewModels
{
    public class AulaEditarViewModel
    {
        public Aula Aula { get; set;}

        public ICollection<Aluno> Aluno { get; set; }

        public DateTime Data { get; set; }

        public String Titulo
        {
            get
            {
                if (Aula != null && Aula.ID != 0)
                {
                    return "Editar aula";
                }
                else
                {
                    return "Cadastrar nova aula";
                }
            }
        }

    }
}