using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Interfaces
{
    public interface ITitularService
    {
        Task<bool> Adicionar(Titular titular);
        Task AtualizarEndereco(Endereco endereco);
    }
}
