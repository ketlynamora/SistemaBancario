using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Interfaces
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
