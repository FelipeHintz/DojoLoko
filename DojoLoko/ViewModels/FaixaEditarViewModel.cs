using DojoLoko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoLoko.ViewModels
{
    public class FaixaEditarViewModel
    {
        public Faixa Faixa { get; set;}

        public String Titulo
        {
            get
            {
                if (Faixa != null && Faixa.ID != 0)
                {
                    return "Editar faixa";
                }
                else
                {
                    return "Cadastrar nova faixa";
                }
            }
        }

    }
}