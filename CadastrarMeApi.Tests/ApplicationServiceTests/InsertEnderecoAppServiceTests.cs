using System;
using CadastrarMeApi.ApplicationService.Services;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Domain.ViewModels.EnderecoViewModels;
using CadastrarMeApi.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadastrarMeApi.Tests.ApplicationServiceTests
{
    [TestClass]
    public class InsertEnderecoAppServiceTests
    {
        private readonly CriarEnderecoViewModel enderecoInvalid = new CriarEnderecoViewModel { Logradouro = "", Bairro = "", Cidade = "", Estado = "", ClienteId = Guid.NewGuid() };
        private readonly CriarEnderecoViewModel enderecoValid = new CriarEnderecoViewModel { Logradouro = "Rua Z", Bairro = "Bairro Z", Cidade = "Cidade Z", Estado = "Estado Z", ClienteId = Guid.NewGuid() };
        private readonly EnderecoApplicationService applicationService = new EnderecoApplicationService(new FakeEnderecoRepository());

        [TestMethod]
        public void Should_interrupt_execution_if_invalid_commands()
        {
            var result = (ResultViewModel)applicationService.InserirEndereco(enderecoInvalid);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Should_persist_data_if_valid_commands()
        {
            var result = (ResultViewModel)applicationService.InserirEndereco(enderecoValid);
            Assert.AreEqual(result.Success, true);
        }
    }
}