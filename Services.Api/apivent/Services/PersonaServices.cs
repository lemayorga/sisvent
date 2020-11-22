// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using apivent.Application.Interfaces;
// using apivent.Application.Repositories;
// using apivent.Infrastructure.Context;
// using apivent.Infrastructure.Models;

// namespace apivent.Services
// {
//     public class PersonaServices : GenericBaseRepository<Persona>, IPersonaService
//     {
//         public PersonaServices(AppContexto context) : base(context) { }

//         public IEnumerable<Persona> TipoPersonas(string tipo)
//         {
            
//             IEnumerable<Persona> tipoPersonas = base.Get(filter: x => x.tipoPersona == tipo);
//             return tipoPersonas;
//         }
//     }
// }