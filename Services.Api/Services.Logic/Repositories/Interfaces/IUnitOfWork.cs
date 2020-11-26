using System;
using Services.Entity.Contexts;
using Services.Logic.Interfaces.Common;

namespace Services.Logic.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IPersonaServices PersonasServ {get;}
    }
}