using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Interfaces
{
    public interface IContaService 
    {
        Task Adicionar(Conta conta);
        Task Atualizar(Conta conta);
        Task<bool> Remover(Guid id);
    }
}
