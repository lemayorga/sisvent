using apivent.Models;
using apivent.Repositories;
using System.Collections.Generic;
using apivent.Repositories;

namespace apivent.Services.Interfaces
{
    public interface IPersonaRepository :  IGenericRepository<Persona>
    {
        IEnumerable<Persona> TipoPersonas(string tipo);        
    }
}