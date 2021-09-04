using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Services
{
    public class TitularService : ITitularService
    {
        private readonly ITitularRepository _titularRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public TitularService(ITitularRepository titularRepository, IEnderecoRepository enderecoRepository)
        {
            _titularRepository = titularRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(Titular titular)
        {
            if (_titularRepository.Buscar(x => x.Cpf_Cnpj == titular.Cpf_Cnpj).Result.Any())
                return false;
            
            await _titularRepository.Adicionar(titular);
            return true;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_titularRepository.ObterDadosTitular(id).Result.Contas.Any())
                return false;

            var endereco = await _enderecoRepository.ObterEnderecoPorTitular(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _titularRepository.Remover(id);
            return true;

        }
    }
}
