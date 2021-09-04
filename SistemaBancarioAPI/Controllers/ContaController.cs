using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using SistemaBancarioAPI.Models;
using SistemaBancarioAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SistemaBancarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaRepository _contaRepository;
        private readonly IContaService _contaService;
        private readonly IMapper _autoMapper;

        public ContaController(IContaRepository contaRepository, IContaService contaService, IMapper autoMapper)
        {
            _contaRepository = contaRepository;
            _contaService = contaService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContaViewModel>> GetAll()
        {
            return _autoMapper.Map<IEnumerable<ContaViewModel>>(await _contaRepository.ObterTodos());
        }

        [HttpGet("{numeroConta}/conta")]
        public async Task<ActionResult<ContaDetailsViewModel>> GetByConta(string numeroConta)
        {
            try
            {
                var contas = await _contaRepository.ObterConta(numeroConta);

                if (contas == null) return NotFound(new { erro = $"Conta {numeroConta} não encontrada" });

                var contaDetails = _autoMapper.Map<ContaDetailsViewModel>(contas);

                return Ok(contaDetails);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método GetByConta. ", ex);
            }

        }

        [HttpGet("{numeroConta}/saldo")]
        public async Task<ActionResult<ContaDetailsViewModel>> GetBySaldo(string numeroConta)
        {
            try
            {
                var contas = await _contaRepository.ObterConta(numeroConta);

                if (contas == null) return NotFound(new { erro = $"Conta {numeroConta} não encontrada"});

                var contaDetails = _autoMapper.Map<ContaDetailsViewModel>(contas);

                return Ok($"Novo saldo: {contaDetails.Saldo}");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método GetBySaldo. ", ex);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Conta>> Post(AddContaInputModel model)
        {
            try
            {
                var novaConta = _autoMapper.Map<Conta>(model);

                await _contaService.Adicionar(novaConta);

                return Ok(novaConta);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método Post. ", ex);
            }

        }

        [HttpPut("{numeroConta}/sacar")]
        public async Task<ActionResult<ContaViewModel>> PutSacar(string numeroConta, [FromBody] decimal valor)
        {
            try
            {
                var conta = await _contaRepository.ObterConta(numeroConta);

                if (conta == null) return NotFound(new { erro = $"Conta {numeroConta} não encontrada" });

                if (valor > conta.Saldo) return BadRequest("Saldo insuficiente");

                conta.Saldo -= valor;

                await _contaService.Atualizar(conta);

                var contaModel = _autoMapper.Map<ContaViewModel>(conta);

                return Ok(contaModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método PutSacar. ", ex);
            }

        }

        [HttpPut("{numeroConta}/depositar")]
        public async Task<ActionResult<ContaViewModel>> PutDepositar(string numeroConta, [FromBody] decimal valor)
        {
            try
            {
                var usuario = await _contaRepository.ObterConta(numeroConta);

                if (usuario == null) return NotFound(new { erro = $"Conta {numeroConta} não encontrada" });

                usuario.Saldo += valor;

                await _contaService.Atualizar(usuario);

                var contaModel = _autoMapper.Map<ContaViewModel>(usuario);

                return Ok(contaModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método PutDepositar. ", ex);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Conta>> Put(Guid id, UpdateContatInputModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Input inválido para atualizar");

                var usuarioAtualizacao = await _contaRepository.ObterContaPorId(id);

                if (usuarioAtualizacao == null) return NotFound(new { erro = $"Usuário Id: {id} não encontrado" });

                usuarioAtualizacao.TipoNomeConta = model.TipoNomeConta;

                await _contaService.Atualizar(usuarioAtualizacao);

                var contaModel = _autoMapper.Map<ContaViewModel>(usuarioAtualizacao);

                return Ok(contaModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método Put. ", ex);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var usuario = await _contaRepository.ObterContaPorId(id);

                if (usuario == null) return NotFound(new { erro = $"Usuário Id: {id} não encontrado" });

                var removerConta = await _contaService.Remover(id);

                if (!removerConta)
                    return BadRequest("A conta só pode ser deletada após o saldo for zerado");

                return Ok("Conta deletada com sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método Delete. ", ex);
            }

        }
    }
}
