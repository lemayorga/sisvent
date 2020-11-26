// using Microsoft.AspNetCore.Mvc;
// using apivent.Application.Interfaces;
// using System.Collections.Generic;
// using apivent.Infrastructure.Models;
// using apivent.Application.Repositories;

// namespace apivent.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class PersonaController : ControllerBaseRepository<Persona> 
//     {
//         private readonly IPersonaService repoPersona;  

//         public PersonaController(IPersonaService _repoPersona) :base(_repoPersona)
//         {
//             repoPersona = _repoPersona;
//         }

//         [HttpGet]
//         [Route("tipo/{tipo}")]
//         public IEnumerable<Persona> GetTiposPersonas([FromRoute]string tipo) => repoPersona.TipoPersonas(tipo);

//     }
// }


using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Services.Logic.Repositories.Interfaces;
using Services.Entity.Common;

namespace apivent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IUnitOfWork repo;  

        public PersonaController(IUnitOfWork _repo) 
        {
            repo = _repo;
        }

        [HttpGet]
        [Route("tipo/{tipo}")]
        public IEnumerable<Persona> GetTiposPersonas([FromRoute]string tipo) => repo.PersonasServ.TipoPersonas(tipo);

    }
}


