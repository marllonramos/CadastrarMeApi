using System;
using CadastrarMeApi.Domain.Shared;

namespace CadastrarMeApi.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DtNascimento { get; private set; }

        public Cliente(string nome, string cpf, DateTime dt)
        {
            Nome = nome;
            CPF = cpf;
            DtNascimento = dt;
        }
    }
}