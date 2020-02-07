using System;
using CadastrarMeApi.ApplicationService.Services;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Domain.ViewModels.EnderecoViewModels;
using CadastrarMeApi.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadastrarMeApi.Tests.ApplicationServiceTests
{
    [TestClass]
    public class UpdateEnderecoAppServiceTests
    {
        private readonly AtualizarEnderecoViewModel enderecoInvalid = new AtualizarEnderecoViewModel { Id = Guid.NewGuid(), Logradouro = "", Bairro = "", Cidade = "", Estado = "", ClienteId = Guid.NewGuid() };
        private readonly AtualizarEnderecoViewModel enderecoValid = new AtualizarEnderecoViewModel { Id = Guid.NewGuid(), Logradouro = "Rua Z", Bairro = "Bairro Z", Cidade = "Cidade Z", Estado = "Estado Z", ClienteId = Guid.NewGuid() };
        private readonly EnderecoApplicationService applicationService = new EnderecoApplicationService(new FakeEnderecoRepository());

        [TestMethod]
        public void Should_interrupt_execution_if_invalid_commands()
        {
            var result = (ResultViewModel)applicationService.AtualizarEndereco(enderecoInvalid);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Should_persist_data_if_valid_commands()
        {
            var result = (ResultViewModel)applicationService.AtualizarEndereco(enderecoValid);
            Assert.AreEqual(result.Success, true);
        }
    }
}