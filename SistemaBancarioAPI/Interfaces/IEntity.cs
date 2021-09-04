using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Interfaces
{
    public interface IEntity
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}
