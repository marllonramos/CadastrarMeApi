using System;
using CadastrarMeApi.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadastrarMeApi.Tests.EntitiesTests
{
    [TestClass]
    public class UpdateClienteTests
    {
        #region Invalid data
        private readonly Cliente cliente = new Cliente("Marllon Ramos", "12240156732", new DateTime(1987, 10, 19));
        private readonly string invalid_nome = "Marllon Ramos Marllon Ramos Marllon Ramos Marllon Ramos";
        private readonly string invalid_cpf = "13340156738";
        private readonly DateTime invalid_dt = new DateTime(1980, 08, 30);
        #endregion

        #region Valid data
        private readonly string valid_nome = "Outro nome válido aqui";
        private readonly string valid_cpf = "12240156732";
        private readonly DateTime valid_dt = new DateTime(1990, 08, 01);
        #endregion

        [TestMethod]
        public void Update_should_return_invalid_if_invalid_commands()
        {
            cliente.Validate();
            cliente.UpdateNome(invalid_nome);
            cliente.UpdateCPF(invalid_cpf);
            cliente.UpdateDataNascimento(invalid_dt);
            cliente.Validate();

            Assert.AreEqual(cliente.Invalid, true);
        }

        [TestMethod]
        public void Update_should_return_valid_if_valid_commands()
        {
            cliente.Validate();
            cliente.UpdateNome(valid_nome);
            cliente.UpdateCPF(valid_cpf);
            cliente.UpdateDataNascimento(valid_dt);
            cliente.Validate();

            Assert.AreEqual(cliente.Valid, true);
        }
    }
}