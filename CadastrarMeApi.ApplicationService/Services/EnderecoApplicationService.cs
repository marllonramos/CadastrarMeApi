using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.Repositories;
using CadastrarMeApi.Domain.ApplicationServices;

namespace CadastrarMeApi.ApplicationService.Services
{
    public class EnderecoApplicationService : IEnderecoApplicationService
    {
        private readonly IEnderecoRepository _repository;
        public EnderecoApplicationService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Endereco> ListarEndereco()
        {
            return _repository.Listar();
        }
        public Endereco InserirEndereco(Endereco model)
        {
            var endereco = new Endereco(model.Logradouro, model.Bairro, model.Cidade, model.Estado);
            _repository.Inserir(endereco);

            return endereco;
        }
        public Endereco AtualizarEndereco(Guid id)
        {
            var resultado = _repository.ListarPorId(id);
            var endereco = new Endereco(resultado.Logradouro, resultado.Bairro, resultado.Cidade, resultado.Estado);
            _repository.Atualizar(endereco);

            return endereco;
        }
        public Endereco ExcluirEndereco(Guid id)
        {
            var endereco = _repository.ListarPorId(id);
            _repository.Excluir(endereco);

            return endereco;
        }
    }
}