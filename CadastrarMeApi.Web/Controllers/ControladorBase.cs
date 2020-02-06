using CadastrarMeApi.SharedKernel;
using CadastrarMeApi.SharedKernel.Events;
using Microsoft.AspNetCore.Mvc;
using CadastrarMeApi.Domain.ViewModels;

namespace CadastrarMeApi.Web.Controllers
{
    public class ControladorBase : ControllerBase
    {
        public IHandler<DomainNotification> Notifications;

        public ControladorBase()
        {
            this.Notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public ResultViewModel CreateResponse(object resultado)
        {
            if (Notifications.HasNotifications())
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Ocorreu um problema ao cadastrar o cliente",
                    Data = resultado
                };
            }

            return new ResultViewModel
            {
                Success = true,
                Message = "Cliente cadastrado com sucesso",
                Data = resultado
            };
        }

        protected void Dispose(bool disposing)
        {
            Notifications.Dispose();
        }
    }
}