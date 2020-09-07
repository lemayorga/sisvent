using System; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using apivent.Models;
using apivent.Services;
using Microsoft.EntityFrameworkCore;
using apivent.Repositories;
using apivent.Services.Interfaces;

namespace apivent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
      //  private readonly PersonaServices personaLogic;
      //  private IGenericRepository<Persona> personaRepository;
      private IPersonaRepository personaRepository; 

        // public PersonaController(IGenericRepository<Persona> _personaRepository)
        // {
        //      personaRepository = _personaRepository;
        // }
          public PersonaController(IPersonaRepository _personaRepository)
        {
             personaRepository = _personaRepository;
        }
        
        [HttpGet]
        [Route("")]
        public IEnumerable<Persona> Get() => personaRepository.Get();

        [HttpGet]
        [Route("{tipo}")]
        public IEnumerable<Persona> GetTiposPersonas(string tipo) => personaRepository.TipoPersonas(tipo);

      // private readonly VentContext ctxt;

      // public PersonaController(VentContext _ctxt)
      // {
      //     ctxt = _ctxt;
      // }

 
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        // {
        //     return await ctxt.Personas.ToListAsync();
        // }

      // [HttpGet]
      //   public ActionResult<IEnumerable<Persona>> GetPersonas()
      //   {
      //       return personaRepository;
      //   }


        // [HttpGet] 
        // public ActionResult Get()
        // {
        // //     // return  Ok(personaLogic.Get());
        // //     // return Ok(apivent.Models.VentContext().
        //   return Ok();
        // }

        // [HttpGet]
        // [Route("persona/tipos")]
        // public IEnumerable<Persona> GetTipoPersonas(string tipo)
        // {
        //     return  personaLogic.TipoPersonas(tipo);
        // }
    }
}