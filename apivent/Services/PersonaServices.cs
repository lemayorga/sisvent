using System.Collections.Generic;
using apivent.Models;
using apivent.Repositories;
using apivent.Services.Interfaces;

namespace apivent.Services
{
    public class PersonaServices : GenericBaseRepository<Persona>, IPersonaRepository
    {

        public PersonaServices(VentContext context):base(context) { }

        public IEnumerable<Persona> TipoPersonas(string tipo)
        {
            IEnumerable<Persona> tipoPersonas = base.Get(filter: x => x.tipoPersona == tipo);
            return tipoPersonas;
        }
    }
}