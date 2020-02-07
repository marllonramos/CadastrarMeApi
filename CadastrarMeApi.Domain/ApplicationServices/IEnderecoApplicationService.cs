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
        IResultViewModel ListarEnderecoPorCliente(Guid id);
        IResultViewModel InserirEndereco(CriarEnderecoViewModel model);
        IResultViewModel AtualizarEndereco(AtualizarEnderecoViewModel model);
        IResultViewModel ExcluirEndereco(Guid id);
    }
}