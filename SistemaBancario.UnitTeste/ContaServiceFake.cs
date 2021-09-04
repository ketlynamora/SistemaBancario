using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.UnitTeste
{
    public class ContaServiceFake : IContaService
    {
        public Task Adicionar(Conta conta)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Conta conta)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
