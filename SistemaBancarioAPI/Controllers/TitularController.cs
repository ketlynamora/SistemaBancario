using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Controllers
{
    public class TitularController : ControllerBase
    {
        private readonly ITitularRepository _titularRepository;
        private readonly ITitularService _titularService;
        private readonly IMapper _autoMapper;


        public TitularController(ITitularRepository titularRepository, ITitularService titularService, IMapper autoMapper)
        {
            _titularRepository = titularRepository;
            _titularService = titularService;
            _autoMapper = autoMapper;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<TitularViewModel>> GetAll()
        {
            return _autoMapper.Map<IEnumerable<TitularViewModel>>(await _titularRepository.ObterTodos());

        }

        [HttpGet("{id:guid}/titular")]
        public async Task<ActionResult<Titular>> GetById(Guid id)
        {
            try
            {
                var titulares = await _titularRepository.ObterDadosTitular(id);

                if (titulares == null) return NotFound("Conta não encontrada");

                var titularModel = _autoMapper.Map<TitularViewModel>(titulares);

                return Ok(titularModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método GetById. ", ex);
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TitularViewModel>> Put(Guid id, AddEnderecoInputModel model)
        {
            try
            {
                var usuario = await _titularRepository.ObterDadosTitular(id);

                if (usuario == null) return NotFound("Conta não encontrado");

                await _titularService.AtualizarEndereco(_autoMapper.Map<Endereco>(model));

                var TitularModel = _autoMapper.Map<TitularViewModel>(usuario);

                return Ok(TitularModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método Put. ", ex);
            }

        }
        
    }
}

