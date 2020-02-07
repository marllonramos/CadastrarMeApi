using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CadastrarMeApi.Domain.Entities;

namespace CadastrarMeApi.Tests.EntitiesTests
{
    [TestClass]
    public class InsertClienteTests
    {
        private readonly Cliente invalid_commands = new Cliente("Marllon Ramos", "11234556799", new DateTime(1987, 10, 19));
        private readonly Cliente valid_commands = new Cliente("Marllon Ramos", "12240156732", new DateTime(1987, 10, 19));
        
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
