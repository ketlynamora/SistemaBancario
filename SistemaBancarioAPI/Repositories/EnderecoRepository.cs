using Microsoft.EntityFrameworkCore;
using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DatabaseContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorTitular(Guid titularId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.TitularId == titularId);
        }
    }
}
