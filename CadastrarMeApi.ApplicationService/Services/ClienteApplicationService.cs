using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.Repositories;
using CadastrarMeApi.Domain.ApplicationServices;
using CadastrarMeApi.Infra;
using CadastrarMeApi.Domain.ViewModels.ClienteViewModels;
using Flunt.Notifications;
using CadastrarMeApi.Domain.ViewModels;

namespace CadastrarMeApi.ApplicationService.Services
{
    public class ClienteApplicationService : Notifiable, IClienteApplicationService
    {
        private readonly IClienteRepository _repository;
        public ClienteApplicationService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            return _repository.Listar();
        }
        public ResultViewModel InserirCliente(CriarClienteViewModel model)
        {
            // fail fast validation
            var cliente = new Cliente(model.Nome, model.CPF, model.DtNascimento);
            cliente.Validate();

            if (cliente.Invalid)
                return new ResultViewModel { Success = false, Message = "Ocorreu um problema ao cadastrar o cliente.", Data = cliente.Notifications };

            _repository.Inserir(cliente);

            return new ResultViewModel { Success = true, Message = "Cliente cadastrado.", Data = cliente };
        }
        public Cliente AtualizarCliente(Guid id)
        {
            var resultado = _repository.ListarPorId(id);
            var cliente = new Cliente(resultado.Nome, resultado.CPF, resultado.DtNascimento);
            _repository.Atualizar(cliente);

            return cliente;
        }
        public Cliente ExcluirCliente(Guid id)
        {
            var cliente = _repository.ListarPorId(id);
            _repository.Excluir(cliente);

            return cliente;
        }
    }
}