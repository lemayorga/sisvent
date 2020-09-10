using Microsoft.AspNetCore.Mvc;
using apivent.Application.Interfaces;
using System.Collections.Generic;
using apivent.Infrastructure.Models;

namespace apivent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase, IControllerBase<Persona>
    {
        private readonly IPersonaService repoPersona;  

        public PersonaController(IPersonaService _repoPersona)
        {
            repoPersona = _repoPersona;
        }

        [HttpPost]
        public IActionResult PostCreate([FromBody] Persona record)
        {
            repoPersona.Add(record);
            repoPersona.Save();
            return Ok(record);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repoPersona.Delete(id);
            if (repoPersona.Save() == 0)
                return BadRequest();

            return Ok(id);    
        }

        [HttpGet("{id}")]
        public IActionResult GetFind(int id)
        {
            var record = repoPersona.GetById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get() => Ok(repoPersona.Get());

        [HttpPut("{id}")]
        public IActionResult PutUpdate(int id, [FromBody] Persona record)
        {
            repoPersona.Update(record);
            if (repoPersona.Save() == 0)
                return BadRequest();
            
            return Ok(record);
        }


        [HttpGet]
        [Route("tipo/{tipo}")]
        public IEnumerable<Persona> GetTiposPersonas([FromRoute]string tipo) => repoPersona.TipoPersonas(tipo);

    }
}

