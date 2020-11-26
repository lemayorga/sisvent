using Services.Entity.Common;
using Services.Entity.Contexts;
using Services.Logic.Interfaces.Common;
using Services.Logic.Repositories.Interfaces;
using Services.Logic.Services.Common;

namespace Services.Logic.Repositories
{
    public class UnitOfWork  : IUnitOfWork
    {
        private AppContexto _dbContext { get; }

        public IPersonaServices PersonasServ => new PersonaServices(_dbContext);

        public UnitOfWork(AppContexto dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}