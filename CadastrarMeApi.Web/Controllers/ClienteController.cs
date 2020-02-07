using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.ApplicationServices;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Domain.ViewModels.ClienteViewModels;

namespace CadastrarMeApi.Web.Controllers
{
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplicationService _service;

        public ClienteController(IClienteApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Cliente> Get()
        {
            return _service.ListarClientes();
        }

        [HttpPost]
        [Route("")]
        public IResultViewModel Post([FromBody]CriarClienteViewModel model)
        {
            return _service.InserirCliente(model);
        }

        [HttpPut]
        [Route("")]
        public IResultViewModel Put([FromBody]AtualizarClienteViewModel model)
        {
            return _service.AtualizarCliente(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public IResultViewModel Delete(Guid id)
        {
            return _service.ExcluirCliente(id);
        }
    }
}