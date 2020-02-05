using System;

namespace CadastrarMeApi.Domain.Shared
{
    public abstract class Entity
    {
        public Guid Id { get; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}