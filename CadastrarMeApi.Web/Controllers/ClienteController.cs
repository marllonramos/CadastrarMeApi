using Microsoft.AspNetCore.Mvc;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.ApplicationServices;
using CadastrarMeApi.Domain.ViewModels;
using CadastrarMeApi.Domain.ViewModels.ClienteViewModels;

namespace CadastrarMeApi.Web.Controllers
{
    public class ClienteController : ControladorBase
    {
        private readonly IClienteApplicationService _service;

        public ClienteController(IClienteApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/cliente")]
        public ResultViewModel Post([FromBody]CriarClienteViewModel model)
        {
            var resultado = _service.InserirCliente(model);

            return CreateResponse(resultado);
        }
    }
}