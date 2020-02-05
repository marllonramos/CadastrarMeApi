using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;

namespace CadastrarMeApi.Domain.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Listar();
        Cliente ListarPorId(Guid id);
        void Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(Cliente cliente);
    }
}