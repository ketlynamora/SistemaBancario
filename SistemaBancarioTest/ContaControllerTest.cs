using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaBancarioAPI.Controllers;
using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;
using System;
using Xunit;


namespace SistemaBancarioTest
{
    public class ContaControllerTest
    {
        [Fact]
        public void DeveriaRetornarErroSeNaoEncontrarAConta()
        {
            var service = new Mock<IContaService>();
            var repository = new Mock<IContaRepository>();
            var mapper = new Mock<IMapper>();

            var conta = new ContaController(repository.Object, service.Object, mapper.Object);

            var okResult = conta.GetByConta("02020");

            Assert.IsType<OkObjectResult>(okResult.Result);

        }
    }
}
