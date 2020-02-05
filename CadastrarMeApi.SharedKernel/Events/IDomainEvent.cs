using System;

namespace CadastrarMeApi.SharedKernel.Events
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}