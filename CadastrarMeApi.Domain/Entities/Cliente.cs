using System;
using CadastrarMeApi.Domain.Shared;
using Flunt.Validations;

namespace CadastrarMeApi.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente() { }

        public Cliente(string nome, string cpf, DateTime dt)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dt;

            // Validate();
        }

        public void UpdateNome(string nome)
        {
            Nome = nome;
        }

        public void UpdateCPF(string cpf)
        {
            Cpf = cpf;
        }

        public void UpdateDataNascimento(DateTime dtNascimento)
        {
            DataNascimento = dtNascimento;
        }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome", "Preencha o Nome")
                .HasMaxLen(Nome, 30, "Nome", "Máximo de 30 caracteres para o Nome")
                .IsNotNullOrEmpty(Cpf, "CPF", "Preencha o CPF")
                .IsTrue(new Contract().ValidationIsCpf(Cpf), "CPF", "CPF inválido")
                .IsNotNull(DataNascimento, "DtNascimento", "Preencha a Data de Nascimento")
            );
        }
    }
}