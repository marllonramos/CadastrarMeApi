using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.ViewModels.ClienteViewModels;

namespace CadastrarMeApi.Domain.ApplicationServices
{
    public interface IClienteApplicationService
    {
        IEnumerable<Cliente> ListarCliente();
        Cliente InserirCliente(CriarClienteViewModel model);
        Cliente AtualizarCliente(Guid id);
        Cliente ExcluirCliente(Guid id);
    }
}