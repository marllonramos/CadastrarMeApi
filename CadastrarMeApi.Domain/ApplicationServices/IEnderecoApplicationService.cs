using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Domain.ViewModels.EnderecoViewModels;

namespace CadastrarMeApi.Domain.ApplicationServices
{
    public interface IEnderecoApplicationService
    {
        IEnumerable<Endereco> ListarEnderecos();
        ResultViewModel ListarEnderecoPorCliente(Guid id);
        ResultViewModel InserirEndereco(CriarEnderecoViewModel model);
        ResultViewModel AtualizarEndereco(AtualizarEnderecoViewModel model);
        ResultViewModel ExcluirEndereco(Guid id);
    }
}