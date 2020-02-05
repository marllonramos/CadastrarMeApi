using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.Repositories;
using CadastrarMeApi.Domain.ApplicationServices;
using CadastrarMeApi.Infra;

namespace CadastrarMeApi.ApplicationService.Services
{
    public class ClienteApplicationService : ApplicationServiceBase, IClienteApplicationService
    {
        private readonly IClienteRepository _repository;
        public ClienteApplicationService(IClienteRepository repository, IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            return _repository.Listar();
        }
        public Cliente InserirCliente(Cliente model)
        {
            var cliente = new Cliente(model.Nome, model.CPF, model.DtNascimento);
            _repository.Inserir(cliente);

            return cliente;
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