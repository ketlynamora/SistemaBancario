using Microsoft.EntityFrameworkCore;
using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext Db;
        protected readonly DbSet<T> DbSet;

        protected Repository(DatabaseContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }
       
        public virtual async Task<T> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        
        public virtual async Task<T> ObterPorNumeroConta(Guid numeroConta)
        {
            return await DbSet.FindAsync(numeroConta);
        }

        public virtual async Task<List<T>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> Adicionar(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            DbSet.Add(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task<T> Atualizar(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            DbSet.Update(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task Remover(Guid id)
        {
            T entity = DbSet.SingleOrDefault(s => s.Id == id);
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

    }
}