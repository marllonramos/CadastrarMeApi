using System;
using System.Collections.Generic;
using CadastrarMeApi.SharedKernel.Events;

namespace CadastrarMeApi.SharedKernel
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}