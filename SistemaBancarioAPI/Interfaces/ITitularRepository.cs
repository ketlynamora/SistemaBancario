using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Interfaces
{
    public interface ITitularRepository : IRepository<Titular>
    {
        Task<Titular> ObterDadosTitular(Guid id);
    }
}
