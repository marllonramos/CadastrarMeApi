using System;
using CadastrarMeApi.ApplicationService.Services;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Domain.ViewModels.ClienteViewModels;
using CadastrarMeApi.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadastrarMeApi.Tests.ApplicationServiceTests
{
    [TestClass]
    public class UpdateClienteAppServiceTests
    {
        private readonly AtualizarClienteViewModel clienteInvalid = new AtualizarClienteViewModel { Id = Guid.NewGuid(), Nome = "", Cpf = "", DataNascimento = DateTime.Now.Date };
        private readonly AtualizarClienteViewModel clienteValid = new AtualizarClienteViewModel { Id = Guid.NewGuid(), Nome = "Marllon Nascimento Ramos", Cpf = "12240156732", DataNascimento = DateTime.Now.Date };
        private readonly ClienteApplicationService applicationService = new ClienteApplicationService(new FakeClienteRepository());

        [TestMethod]
        public void Should_interrupt_execution_if_invalid_commands()
        {
            var result = (ResultViewModel)applicationService.AtualizarCliente(clienteInvalid);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Should_persist_data_if_valid_commands()
        {
            var result = (ResultViewModel)applicationService.AtualizarCliente(clienteValid);
            Assert.AreEqual(result.Success, true);
        }
    }
}