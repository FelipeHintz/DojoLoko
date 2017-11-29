﻿using DojoLoko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoLoko.ViewModels
{
    public class TipodeAssociacaoEditarViewModel
    {
        public TipoDeAssociacao TipodeAssociacao { get; set;}

        public String Titulo
        {
            get
            {
                if (TipodeAssociacao != null && TipodeAssociacao.ID != 0)
                {
                    return "Editar tipo de associação";
                }
                else
                {
                    return "Cadastrar tipo de associação";
                }
            }
        }

    }
}