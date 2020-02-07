using System;
using CadastrarMeApi.Domain.Shared;
using Flunt.Validations;

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
        }

        public void UpdateLogradouro(string logradouro)
        {
            Logradouro = logradouro;
        }

        public void UpdateBairro(string bairro)
        {
            Bairro = bairro;
        }

        public void UpdateCidade(string cidade)
        {
            Cidade = cidade;
        }

        public void UpdateEstado(string estado)
        {
            Estado = estado;
        }

        public void UpdateEnderecoPorCliente(Guid id)
        {
            ClienteId = id;
        }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Logradouro, "Logradouro", "Preencha o Logradouro")
                .HasMaxLen(Logradouro, 50, "Logradouro", "Máximo de 50 caracteres para o Logradouro")
                .IsNotNullOrEmpty(Bairro, "Bairro", "Preencha o Bairro")
                .HasMaxLen(Bairro, 40, "Bairro", "Máximo de 40 caracteres para o Bairro")
                .IsNotNullOrEmpty(Cidade, "Cidade", "Preencha a Cidade")
                .HasMaxLen(Cidade, 40, "Cidade", "Máximo de 40 caracteres para a Cidade")
                .IsNotNullOrEmpty(Estado, "Estado", "Preencha o Estado")
                .HasMaxLen(Estado, 40, "Estado", "Máximo de 40 caracteres para o Estado")
            );
        }
    }
}