using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace CadastrarMeApi.Domain.Shared
{
    public abstract class Entity : Notifiable, IValidatable
    {
        public Guid Id { get; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Validate();
    }
}