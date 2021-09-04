using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Interfaces
{
    public interface IContaRepository : IRepository<Conta>
    {
        Task<Conta> ObterContaPorTitular(Guid titularId);
        Task<Conta> ObterConta(string numeroConta);
        Task<Conta> ObterContaPorId(Guid id);
        Task<IEnumerable<Conta>> ObterContasTitulares();
    }
}
