using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CadastrarMeApi.Domain.Entities;

namespace CadastrarMeApi.Tests.DomainTests
{
    [TestClass]
    public class InsertClienteTests
    {
        // dotnet test  -> para executar os testes
        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            var cliente = new Cliente("Marllon Ramos", "11234556799", new DateTime(1987, 10, 19));
            cliente.Validate();

            Assert.AreEqual(cliente.Invalid, true);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            var cliente = new Cliente("Marllon Ramos", "12240156732", new DateTime(1987, 10, 19));
            cliente.Validate();

            Assert.AreEqual(cliente.Valid, true);
        }
    }
}
