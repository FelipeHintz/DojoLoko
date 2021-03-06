﻿using DojoLoko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoLoko.ViewModels
{
    public class AlunoEditarViewModel
    {
        public Aluno Aluno { get; set;}

        public IEnumerable<Faixa> Faixa { get; set; }

        public IEnumerable<TipoDeAssociacao> TipoDeAssociacao { get; set; }

        public ICollection<Aula> Aula { get; set; }

        public String Titulo
        {
            get
            {
                if (Aluno != null && Aluno.ID != 0)
                {
                    return "Editar cliente";
                }
                else
                {
                    return "Cadastrar novo cliente";
                }
            }
        }

    }
}