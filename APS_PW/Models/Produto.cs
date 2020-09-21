using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Produto : Model
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public double Estoque { get; set; }
    }
}
