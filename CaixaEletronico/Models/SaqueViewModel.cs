using System.Collections.Generic;
using CaixaEletronico.Model.Enums;

namespace CaixaEletronico.Models
{
    public class SaqueViewModel
    {
        public decimal ValorRequisitado { get; set; }

        public string Erro { get; set; }

        public Dictionary<TipoNota, int> ValoresSaque { get; set;}
    }
}
