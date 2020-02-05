using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;

namespace CadastrarMeApi.Domain.Repositories
{
    public interface IEnderecoRepository
    {
        IEnumerable<Endereco> Listar();
        Endereco ListarPorId(Guid id);
        void Inserir(Endereco endereco);
        void Atualizar(Endereco endereco);
        void Excluir(Endereco endereco);
    }
}