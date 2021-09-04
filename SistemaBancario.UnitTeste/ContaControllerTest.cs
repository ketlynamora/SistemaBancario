using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBancarioAPI.Controllers;
using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Interfaces;

namespace SistemaBancario.UnitTeste
{
    public class ContaControllerTest
    {
        [TestClass]
        [TestCategory("UnitTest > Controllers > Conta")]
        public class PrecosControllerTest
        {
            [TestMethod]
            public void DeveriaRetornarErroSeNaoEncontrarOProduto()
            {
                var repository = new ContaRepositoryFake();
                var service = new ContaServiceFake();
                var conta = new ContaController(repository, service);

                var result = conta.GetByConta("0000");


                Assert.AreEqual(404, ((NotFoundObjectResult)result).StatusCode);
            }

            [TestMethod]
            public void DeveriaRetornarPrecoTotalIgualAValorProduto()
            {
                var prodMock = new ProdutoRepositoryFake(new ProdutoDto(33, "Novo Produto", 1022.33m, false));
                var taxaMock = new TaxaEntregaRepositoryFake();
                var precoCtrl = new PrecosController(prodMock, taxaMock);

                var res = precoCtrl.ObterPreco(33, 75021010);
                var objRes = (ObterPrecoResponse)((OkObjectResult)res).Value;

                Assert.AreEqual(0, objRes.ValorEntrega);
                Assert.AreEqual(1022.33m, objRes.PrecoTotal);
                Assert.AreEqual(1022.33m, objRes.ValorProduto);
            }

            [TestMethod]
            public void DeveriaRetornarValorEntregaEPrecoTotalIgualASomaDoProdutoEEntrega()
            {
                var prodMock = new ProdutoRepositoryFake(new ProdutoDto(1, "TV 75 polegadas", 7044.75m, true));
                var taxaMock = new TaxaEntregaRepositoryFake();
                var precoCtrl = new PrecosController(prodMock, taxaMock);

                var res = precoCtrl.ObterPreco(1, 75021010);
                var objRes = (ObterPrecoResponse)((OkObjectResult)res).Value;

                Assert.AreEqual(211.34m, objRes.ValorEntrega);
                Assert.AreEqual(7044.75m, objRes.ValorProduto);
                Assert.AreEqual(7256.09m, objRes.PrecoTotal);
            }
        }
    }
