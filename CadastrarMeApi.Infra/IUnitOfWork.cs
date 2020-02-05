using System;

namespace CadastrarMeApi.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}