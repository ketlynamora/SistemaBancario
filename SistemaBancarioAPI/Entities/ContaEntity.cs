using SistemaBancarioAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Entities
{
    public abstract class ContaEntity : BaseEntity, IEntity
    {
        protected ContaEntity()
        {
            Agencia = number.Next(1, 300).ToString("0000");
            Conta = number.Next(1000, 5000).ToString("00000-0");
            CreationDate = DateTime.Now;
        }

        Random number = new Random();
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}
