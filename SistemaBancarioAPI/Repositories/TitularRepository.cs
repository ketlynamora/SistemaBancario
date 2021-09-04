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
    public class TitularRepository : Repository<Titular>, ITitularRepository
    {
        public TitularRepository(DatabaseContext context) : base(context) { }

        public async Task<Titular> ObterDadosTitular(Guid id)
        {
            return await Db.Titulares.AsNoTracking().Include(n => n.Contas).Include(e => e.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
