using System.Collections.Generic;
using Services.Entity.Common;
using Services.Logic.Repositories;
using Services.Logic.Repositories.Interfaces;

namespace Services.Logic.Interfaces.Common
{
    public interface IPersonaServices : IBaseRepository<Persona>
    {
        IEnumerable<Persona> TipoPersonas(string tipo);
    }
}
