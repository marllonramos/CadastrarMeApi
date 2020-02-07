using System;
using CadastrarMeApi.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadastrarMeApi.Tests.EntitiesTests
{
    [TestClass]
    public class InsertEnderecoTests
    {
        private readonly Endereco invalid_commands = new Endereco("Avenida Rio Branco n 227 - Centro Rio de Janeiro, Brasil", "Centro Centro Centro Centro Centro Centro", "", "", Guid.NewGuid());
        private readonly Endereco valid_commands = new Endereco("Av. Rio Branco n 300", "Centro", "Rio de Janeiro", "RJ", Guid.NewGuid());
        
        [TestMethod]
        public void Should_return_invalid_if_invalid_commands()
        {
            invalid_commands.Validate();
            Assert.AreEqual(invalid_commands.Invalid, true);
        }

        [TestMethod]
        public void Should_return_valid_if_valid_commands()
        {
            valid_commands.Validate();
            Assert.AreEqual(valid_commands.Valid, true);
        }
    }
}