using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Entities
{
    public class Titular : BaseEntity
    {
        public Titular()
        {

        }
        public Titular(DateTime dtNascimento, string nome, string cpf_Cnpj, Endereco endereco)
        {
            DtNascimento = dtNascimento;
            Nome = nome;
            Cpf_Cnpj = cpf_Cnpj;
            Endereco = endereco;
        }

        public DateTime DtNascimento { get; set; }
        public string Nome { get; set; }
        public string Cpf_Cnpj { get; set; }
        public Endereco Endereco { get; set; }

        /* EF Relations */
        public IEnumerable<Conta> Contas { get; set; }

    }
}
