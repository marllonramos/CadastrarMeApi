using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.Repositories;

namespace CadastrarMeApi.Tests.FakeRepositories
{
    public class FakeEnderecoRepository : IEnderecoRepository
    {
        public void Atualizar(Endereco endereco) { }

        public void Excluir(Endereco endereco) { }

        public void Inserir(Endereco endereco) { }

        public IEnumerable<Endereco> Listar()
        {
            Endereco endereco = new Endereco("Rua A", "Bairro A", "Cidade A", "A", Guid.NewGuid());
            Endereco endereco2 = new Endereco("Rua B", "Bairro B", "Cidade B", "B", Guid.NewGuid());
            Endereco endereco3 = new Endereco("Rua C", "Bairro C", "Cidade C", "C", Guid.NewGuid());

            List<Endereco> list = new List<Endereco>();
            list.Add(endereco);
            list.Add(endereco2);
            list.Add(endereco3);

            return list;
        }

        public Endereco ListarPorCliente(Guid id)
        {
            Endereco endereco = new Endereco("Rua Teste", "Bairro Teste", "Cidade Teste", "Teste", id);
            return endereco;
        }

        public Endereco ListarPorId(Guid id)
        {
            Endereco endereco = new Endereco("Rua Teste", "Bairro Teste", "Cidade Teste", "Teste", Guid.NewGuid());
            return endereco;
        }
    }
}