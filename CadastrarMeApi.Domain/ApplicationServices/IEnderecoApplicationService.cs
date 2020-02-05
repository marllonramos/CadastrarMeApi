using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;

namespace CadastrarMeApi.Domain.ApplicationServices
{
    public interface IEnderecoApplicationService
    {
        IEnumerable<Endereco> ListarEndereco();
        Endereco InserirEndereco(Endereco endereco);
        Endereco AtualizarEndereco(Guid id);
        Endereco ExcluirEndereco(Guid id);
    }
}