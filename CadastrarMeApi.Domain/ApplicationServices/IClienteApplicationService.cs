using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Domain.ViewModels.ClienteViewModels;

namespace CadastrarMeApi.Domain.ApplicationServices
{
    public interface IClienteApplicationService
    {
        IEnumerable<Cliente> ListarClientes();
        IResultViewModel InserirCliente(CriarClienteViewModel model);
        IResultViewModel AtualizarCliente(AtualizarClienteViewModel model);
        IResultViewModel ExcluirCliente(Guid id);
    }
}