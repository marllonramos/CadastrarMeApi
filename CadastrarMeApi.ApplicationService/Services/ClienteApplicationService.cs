using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.Repositories;
using CadastrarMeApi.Domain.ApplicationServices;
using CadastrarMeApi.Infra;
using CadastrarMeApi.Domain.ViewModels.ClienteViewModels;
using CadastrarMeApi.Domain.ViewModels;
using Flunt.Notifications;

namespace CadastrarMeApi.ApplicationService.Services
{
    public class ClienteApplicationService : Notifiable, IClienteApplicationService
    {
        private readonly IClienteRepository _repository;
        public ClienteApplicationService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return _repository.Listar();
        }
        public ResultViewModel InserirCliente(CriarClienteViewModel model)
        {
            // fail fast validation
            var cliente = new Cliente(model.Nome, model.Cpf, model.DataNascimento);
            cliente.Validate();

            if (cliente.Invalid)
                return new ResultViewModel { Success = false, Message = "Ocorreu um problema ao cadastrar o cliente.", Data = cliente.Notifications };

            _repository.Inserir(cliente);

            return new ResultViewModel { Success = true, Message = "Cliente cadastrado.", Data = cliente };
        }
        public ResultViewModel AtualizarCliente(AtualizarClienteViewModel model)
        {
            var clienteModel = new Cliente(model.Nome, model.Cpf, model.DataNascimento);
            clienteModel.Validate();

            if (clienteModel.Invalid)
                return new ResultViewModel { Success = false, Message = "Ocorreu um problema ao atualizar o cliente.", Data = clienteModel.Notifications };

            var cliente = _repository.ListarPorId(model.Id);

            cliente.UpdateNome(clienteModel.Nome);
            cliente.UpdateCPF(clienteModel.Cpf);
            cliente.UpdateDataNascimento(clienteModel.DataNascimento);

            _repository.Atualizar(cliente);

            return new ResultViewModel { Success = true, Message = "Cliente atualizado.", Data = cliente };
        }
        public ResultViewModel ExcluirCliente(Guid id)
        {
            var cliente = _repository.ListarPorId(id);
            _repository.Excluir(cliente);

            return new ResultViewModel { Success = true, Message = "Cliente excluído.", Data = cliente };
        }
    }
}