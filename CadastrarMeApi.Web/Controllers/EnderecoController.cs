using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.ApplicationServices;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Domain.ViewModels.EnderecoViewModels;

namespace CadastrarMeApi.Web.Controllers
{
    [Route("api/endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoApplicationService _service;

        public EnderecoController(IEnderecoApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Endereco> Get()
        {
            return _service.ListarEnderecos();
        }

        [HttpGet]
        [Route("cliente/{id}")]
        public ResultViewModel GetByClientId(Guid id)
        {
            return _service.ListarEnderecoPorCliente(id);
        }

        [HttpPost]
        [Route("")]
        public ResultViewModel Post([FromBody]CriarEnderecoViewModel model)
        {
            return _service.InserirEndereco(model);
        }

        [HttpPut]
        [Route("")]
        public ResultViewModel Put([FromBody]AtualizarEnderecoViewModel model)
        {
            return _service.AtualizarEndereco(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public ResultViewModel Delete(Guid id)
        {
            return _service.ExcluirEndereco(id);
        }
    }
}