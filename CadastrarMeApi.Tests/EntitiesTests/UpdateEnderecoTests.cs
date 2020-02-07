using System;
using CadastrarMeApi.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadastrarMeApi.Tests.EntitiesTests
{
    [TestClass]
    public class UpdateEnderecoTests
    {
        #region Invalid data
        private readonly Endereco endereco = new Endereco("Rua Buenos Aires", "Centro", "Rio de Janeiro", "RJ", Guid.NewGuid());
        private readonly string invalid_logradouro = "Marllon Ramos Marllon Ramos Marllon Ramos Marllon Ramos";
        private readonly string invalid_bairro = "";
        private readonly string invalid_cidade = "Alguma cidade qualquer no centro do Rio de Janeiro";
        private readonly string invalid_estado = "";
        private readonly Guid invalid_clienteId = Guid.NewGuid();
        #endregion

        #region Valid data
        private readonly string valid_logradouro = "Rua da Pátria";
        private readonly string valid_bairro = "Niterói";
        private readonly string valid_cidade = "São Paulo";
        private readonly string valid_estado = "SP";
        private readonly Guid valid_clienteId = Guid.NewGuid();
        #endregion

        [TestMethod]
        public void Update_should_return_invalid_if_invalid_commands()
        {
            endereco.Validate();
            endereco.UpdateLogradouro(invalid_logradouro);
            endereco.UpdateBairro(invalid_bairro);
            endereco.UpdateCidade(invalid_cidade);
            endereco.UpdateEstado(invalid_estado);
            endereco.UpdateEnderecoPorCliente(invalid_clienteId);
            endereco.Validate();

            Assert.AreEqual(endereco.Invalid, true);
        }

        [TestMethod]
        public void Update_should_return_valid_if_valid_commands()
        {
            endereco.Validate();
            endereco.UpdateLogradouro(valid_logradouro);
            endereco.UpdateBairro(valid_bairro);
            endereco.UpdateCidade(valid_cidade);
            endereco.UpdateEstado(valid_estado);
            endereco.UpdateEnderecoPorCliente(valid_clienteId);
            endereco.Validate();

            Assert.AreEqual(endereco.Valid, true);
        }
    }
}