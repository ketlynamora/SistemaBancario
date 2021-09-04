using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Adicionar(T entity);
        Task<T> ObterPorId(Guid id);
        Task<T> ObterPorNumeroConta(Guid numeroConta);
        Task<List<T>> ObterTodos();
        Task<T> Atualizar(T entity);
        Task Remover(Guid id);
        Task<int> SaveChanges();
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);

    }
}