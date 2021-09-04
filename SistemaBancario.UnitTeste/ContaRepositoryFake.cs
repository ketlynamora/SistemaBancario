using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.UnitTeste
{
    class ContaRepositoryFake : IContaRepository
    {
        public Task<Conta> Adicionar(Conta entity)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> Atualizar(Conta entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Conta>> Buscar(Expression<Func<Conta, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> ObterConta(string numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> ObterContaPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> ObterContaPorTitular(Guid titularId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Conta>> ObterContasTitulares()
        {
            throw new NotImplementedException();
        }

        public Task<Conta> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> ObterPorNumeroConta(Guid numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task<List<Conta>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
