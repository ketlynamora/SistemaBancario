using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Models
{
    public class ContaViewModel
    {
        public Guid TitularId { get; set; }
        public string Conta { get; set; }
        public string TipoNomeConta { get; set; }
        public decimal Saldo { get; set; }
    }
}
