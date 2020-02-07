using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.Repositories;

namespace CadastrarMeApi.Tests.FakeRepositories
{
    public class FakeClienteRepository : IClienteRepository
    {
        public void Atualizar(Cliente cliente) { }

        public void Excluir(Cliente cliente) { }

        public void Inserir(Cliente cliente) { }

        public IEnumerable<Cliente> Listar()
        {
            Cliente cliente = new Cliente("Marllon Ramos", "12240156732", DateTime.Now.Date);
            Cliente cliente2 = new Cliente("Osmar Nollram", "12240156732", DateTime.Now.Date);
            Cliente cliente3 = new Cliente("Nollram Osmar", "12240156732", DateTime.Now.Date);

            List<Cliente> list = new List<Cliente>();
            list.Add(cliente);
            list.Add(cliente2);
            list.Add(cliente3);

            return list;
        }

        public Cliente ListarPorId(Guid id)
        {
            Cliente cliente = new Cliente("Marllon Ramos", "12240156732", DateTime.Now.Date);
            return cliente;
        }
    }
}