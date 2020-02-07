using System;
using System.Collections.Generic;
using CadastrarMeApi.ApplicationService.Services;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadastrarMeApi.Tests.ApplicationServiceTests
{
    [TestClass]
    public class ListClientesAppServiceTests
    {
        private readonly ClienteApplicationService applicationService = new ClienteApplicationService(new FakeClienteRepository());

        [TestMethod]
        public void Should_show_results_if_list_different_zero()
        {
            var result = applicationService.ListarClientes();
            Assert.AreNotEqual(result.ToString().Length, 0);
        }
    }
}