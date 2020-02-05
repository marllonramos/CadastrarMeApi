using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;

namespace CadastrarMeApi.Domain.ApplicationServices
{
    public interface IClienteApplicationService
    {
        IEnumerable<Cliente> ListarCliente();
        Cliente InserirCliente(Cliente cliente);
        Cliente AtualizarCliente(Guid id);
        Cliente ExcluirCliente(Guid id);
    }
}