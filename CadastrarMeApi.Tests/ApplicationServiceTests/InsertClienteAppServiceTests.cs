using System;
using CadastrarMeApi.ApplicationService.Services;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Domain.ViewModels.ClienteViewModels;
using CadastrarMeApi.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadastrarMeApi.Tests.ApplicationServiceTests
{
    [TestClass]
    public class InsertClienteAppServiceTests
    {
        private readonly CriarClienteViewModel clienteInvalid = new CriarClienteViewModel { Nome = "", Cpf = "", DataNascimento = DateTime.Now.Date };
        private readonly CriarClienteViewModel clienteValid = new CriarClienteViewModel { Nome = "Marllon Ramos", Cpf = "12240156732", DataNascimento = DateTime.Now.Date };
        private readonly ClienteApplicationService applicationService = new ClienteApplicationService(new FakeClienteRepository());

        [TestMethod]
        public void Update_Should_interrupt_execution_if_invalid_commands()
        {
            var result = (ResultViewModel)applicationService.InserirCliente(clienteInvalid);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Update_Should_persist_data_if_valid_commands()
        {
            var result = (ResultViewModel)applicationService.InserirCliente(clienteValid);
            Assert.AreEqual(result.Success, true);
        }
    }
}