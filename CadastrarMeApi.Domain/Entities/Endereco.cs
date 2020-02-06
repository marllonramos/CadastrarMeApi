using System;
using CadastrarMeApi.Domain.Shared;
using CadastrarMeApi.Domain.Validations;

namespace CadastrarMeApi.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        public Endereco() { }

        public Endereco(string logradouro, string bairro, string cidade, string estado, Guid clienteId)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            ClienteId = clienteId;

            this.ValidLogradouro();
            this.ValidBairro();
            this.ValidCidade();
            this.ValidEstado();
        }
    }
}