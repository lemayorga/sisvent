using System.Collections.Generic;
using Services.Entity.Common;
using Services.Entity.Contexts;
using Services.Logic.Interfaces.Common;
using Services.Logic.Repositories;

namespace Services.Logic.Services.Common
{
    public class PersonaServices : BaseRepository<Persona>, IPersonaServices
    {
        public PersonaServices(AppContexto context) : base(context) { }
        
        public IEnumerable<Persona> TipoPersonas(string tipo)
        {
            IEnumerable<Persona> tipoPersonas = base.Get(filter: x => x.tipoPersona == tipo);
            return tipoPersonas;
        }
    }
}