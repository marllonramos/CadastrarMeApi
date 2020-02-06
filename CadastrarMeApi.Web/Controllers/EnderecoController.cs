using CadastrarMeApi.Domain.ApplicationServices;

namespace CadastrarMeApi.Web.Controllers
{
    public class EnderecoController
    {
        private readonly IEnderecoApplicationService _service;

        public EnderecoController(IEnderecoApplicationService service)
        {
            _service = service;
        }
    }
}