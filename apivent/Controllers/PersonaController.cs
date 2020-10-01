using Microsoft.AspNetCore.Mvc;
using apivent.Application.Interfaces;
using System.Collections.Generic;
using apivent.Infrastructure.Models;
using apivent.Application.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace apivent.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBaseRepository<Persona> 
    {
        private readonly IPersonaService repoPersona;  

        public PersonaController(IPersonaService _repoPersona) :base(_repoPersona)
        {
            repoPersona = _repoPersona;
        }

        [HttpGet]
        [Route("tipo/{tipo}")]
        public IEnumerable<Persona> GetTiposPersonas([FromRoute]string tipo) => repoPersona.TipoPersonas(tipo);

    }
}

