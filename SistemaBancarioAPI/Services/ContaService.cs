using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly ITitularRepository _titularRepository;
        private readonly IEnderecoRepository _enderecoRepository;

       
        public ContaService(IContaRepository contaRepository, ITitularRepository titularRepository, IEnderecoRepository enderecoRepository)
        {
            _contaRepository = contaRepository;
            _titularRepository = titularRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Conta conta)
        {
            await _contaRepository.Adicionar(conta);
        }

        public async Task Atualizar(Conta conta)
        {
            await _contaRepository.Atualizar(conta);
        }

        public async Task<bool> Remover(Guid id)
        {
            var conta = await _contaRepository.ObterContaPorId(id);

            if (conta.Saldo > 0)
                return false;

            var titular = await _titularRepository.ObterPorId(conta.TitularId);
            var endereco = await _enderecoRepository.ObterEnderecoPorTitular(conta.TitularId);

            if (endereco != null && titular != null)
            {
                await _titularRepository.Remover(titular.Id);

                await _enderecoRepository.Remover(endereco.Id);
            }

            await _contaRepository.Remover(id);
            return true;
        }
    }
}
