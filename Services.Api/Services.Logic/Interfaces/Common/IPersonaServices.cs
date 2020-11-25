using System.Collections.Generic;
using Services.Entity.Common;
using Services.Logic.Repositories;

namespace Services.Logic.Interfaces.Common
{
    public interface IPersonaServices :IGenericRepository<Persona>
    {
        IEnumerable<Persona> TipoPersonas(string tipo);
    }
}
