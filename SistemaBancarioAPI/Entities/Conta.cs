using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Entities
{
    public class Conta : ContaEntity
    {
        public Conta()
        {

        }
      
        public Guid TitularId { get; set; }
        public string TipoNomeConta { get; set; }
        public decimal Saldo { get; set; }


        /* EF Relation */
        public Titular Titular { get; set; }
    }
}
