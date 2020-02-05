using CadastrarMeApi.SharedKernel;
using CadastrarMeApi.SharedKernel.Events;
using Microsoft.AspNetCore.Mvc;

namespace CadastrarMeApi.Web.Controllers
{
    public class ControladorBase : ControllerBase
    {
        public IHandler<DomainNotification> Notifications;

        public ControladorBase()
        {
            this.Notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        protected void Dispose(bool disposing)
        {
            Notifications.Dispose();
        }
    }
}