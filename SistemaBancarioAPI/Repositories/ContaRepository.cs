using Microsoft.EntityFrameworkCore;
using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Repositories
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(DatabaseContext context) : base(context) { }

        public async Task<Conta> ObterConta(string numeroConta)
        {
            return await Db.Contas.AsNoTracking().Include(n => n.Titular).Include(e => e.Titular.Endereco)
                .FirstOrDefaultAsync(p => p.Conta == numeroConta);
        }
        public async Task<Conta> ObterContaPorId(Guid id)
        {
            return await Db.Contas.AsNoTracking().Include(n => n.Titular).Include(e => e.Titular.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Conta> ObterContaPorTitular(Guid id)
        {
            return await Db.Contas.AsNoTracking().Include(f => f.Titular).Include(e => e.Titular.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Conta>> ObterContasTitulares()
        {
            return await Db.Contas.AsNoTracking().Include(f => f.Titular).Include(e => e.Titular.Endereco)
                .OrderBy(p => p.Id).ToListAsync();
        }
    }
}
