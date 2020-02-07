using System;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.Repositories;
using CadastrarMeApi.Domain.ApplicationServices;
using CadastrarMeApi.Infra;
using CadastrarMeApi.Domain.ViewModels.EnderecoViewModels;
using CadastrarMeApi.Domain.ViewModels;
using Flunt.Notifications;

namespace CadastrarMeApi.ApplicationService.Services
{
    public class EnderecoApplicationService : Notifiable, IEnderecoApplicationService
    {
        private readonly IEnderecoRepository _repository;
        public EnderecoApplicationService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Endereco> ListarEnderecos()
        {
            return _repository.Listar();
        }

        public IResultViewModel ListarEnderecoPorCliente(Guid id)
        {
            var endereco = _repository.ListarPorCliente(id);
            endereco.Validate();

            if (endereco.Invalid)
                return new ResultViewModel { Success = false, Message = "Ocorreu um problema ao consultar endereço pelo cliente.", Data = endereco.Notifications };

            return new ResultViewModel { Success = true, Message = "Sucesso", Data = endereco };
        }

        public IResultViewModel InserirEndereco(CriarEnderecoViewModel model)
        {
            var endereco = new Endereco(model.Logradouro, model.Bairro, model.Cidade, model.Estado, model.ClienteId);
            endereco.Validate();

            if (endereco.Invalid)
                return new ResultViewModel { Success = false, Message = "Ocorreu um problema ao cadastrar o endereço.", Data = endereco.Notifications };

            _repository.Inserir(endereco);

            return new ResultViewModel { Success = true, Message = "Endereço cadastrado.", Data = endereco };
        }
        public IResultViewModel AtualizarEndereco(AtualizarEnderecoViewModel model)
        {
            var enderecoModel = new Endereco(model.Logradouro, model.Bairro, model.Cidade, model.Estado, model.ClienteId);
            enderecoModel.Validate();

            if (enderecoModel.Invalid)
                return new ResultViewModel { Success = false, Message = "Ocorreu um problema ao atualizar o endereço.", Data = enderecoModel.Notifications };

            var endereco = _repository.ListarPorId(model.Id);

            endereco.UpdateLogradouro(enderecoModel.Logradouro);
            endereco.UpdateBairro(enderecoModel.Bairro);
            endereco.UpdateCidade(enderecoModel.Cidade);
            endereco.UpdateEstado(enderecoModel.Estado);
            endereco.UpdateEnderecoPorCliente(enderecoModel.ClienteId);

            _repository.Atualizar(endereco);

            return new ResultViewModel { Success = true, Message = "Endereço atualizado.", Data = endereco };
        }
        public IResultViewModel ExcluirEndereco(Guid id)
        {
            var endereco = _repository.ListarPorId(id);
            _repository.Excluir(endereco);

            return new ResultViewModel { Success = true, Message = "Endereço excluído.", Data = endereco };
        }
    }
}