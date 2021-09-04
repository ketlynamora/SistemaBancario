using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Models
{
    public class ContaDetailsViewModel
    {
        public string TipoNomeConta { get; set; }
        public string Conta { get; set; }
        public decimal Saldo { get; set; }
        public TitularViewModel Titular { get; set; }

    }

    public class TitularViewModel
    {
        public string Nome { get; set; }
        public string DtNascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }

    public class EnderecoViewModel
    {
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
