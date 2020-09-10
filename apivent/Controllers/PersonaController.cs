using Microsoft.AspNetCore.Mvc;
using apivent.Application.Interfaces;
using System.Collections.Generic;
using apivent.Infrastructure.Models;

namespace apivent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService repoPersona;  

        public PersonaController(IPersonaService _repoPersona)
        {
            repoPersona = _repoPersona;
        }      

        [HttpGet]
        [Route("")]
        public IEnumerable<Persona> GetPersonas() => repoPersona.Get();
        
        [HttpGet]
        [Route("{tipo}")]
        public IEnumerable<Persona> GetTiposPersonas([FromRoute]string tipo) => repoPersona.TipoPersonas(tipo);

    }
}