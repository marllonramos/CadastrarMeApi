using CadastrarMeApi.Domain.ApplicationServices;

namespace CadastrarMeApi.Web.Controllers
{
    public class ClienteController : ControladorBase
    {
        private readonly IClienteApplicationService _service;

        public ClienteController(IClienteApplicationService service)
        {
            _service = service;
        }
    }
}