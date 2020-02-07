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
        ResultViewModel InserirCliente(CriarClienteViewModel model);
        ResultViewModel AtualizarCliente(AtualizarClienteViewModel model);
        ResultViewModel ExcluirCliente(Guid id);
    }
}