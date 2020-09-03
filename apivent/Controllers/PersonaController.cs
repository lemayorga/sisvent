using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using apivent.Models;
using apivent.Services;

namespace apivent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaServices personaLogic;
        
        public PersonaController(PersonaServices svLogic)
        {
            personaLogic = svLogic;
        }

        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            return  personaLogic.Get();
        }

        [HttpGet]
        public IEnumerable<Persona> TipoPersonas(string tipo)
        {
            return  personaLogic.TipoPersonas(tipo);
        }
    }
}