using SistemaBancarioAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Models
{
    public class AddTitularInputModel
    {
        public DateTime DtNascimento { get; set; }
        public string Nome { get; set; }
        public string Cpf_Cnpj { get; set; }
        public AddEnderecoInputModel Endereco { get; set; }
    }
}
