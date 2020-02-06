using System;
using CadastrarMeApi.Domain.Shared;
using Flunt.Validations;

namespace CadastrarMeApi.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DtNascimento { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente() { }

        public Cliente(string nome, string cpf, DateTime dt)
        {
            Nome = nome;
            CPF = cpf;
            DtNascimento = dt;

            Validate();
        }

        public void UpdateNome(string nome)
        {
            Nome = nome;
        }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome", "Preencha o Nome")
                .HasMaxLen(Nome, 30, "Nome", "Máximo de 30 caracteres para o Nome")
                .IsNotNullOrEmpty(CPF, "CPF", "Preencha o CPF")
                .IsTrue(new Contract().ValidationIsCpf(CPF), "CPF", "CPF inválido")
                .IsNotNull(DtNascimento, "DtNascimento", "Preencha a Data de Nascimento")
            );
        }
    }
}