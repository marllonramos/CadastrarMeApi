using CadastrarMeApi.Infra;
using CadastrarMeApi.SharedKernel;
using CadastrarMeApi.SharedKernel.Events;

namespace CadastrarMeApi.ApplicationService
{
    public class ApplicationServiceBase
    {
        private IUnitOfWork _uow;
        private IHandler<DomainNotification> _notifications;

        public ApplicationServiceBase(IUnitOfWork uow)
        {
            _uow = uow;
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;

            _uow.Commit();
            return true;
        }
    }
}