// using Microsoft.AspNetCore.Mvc;
// using apivent.Application.Interfaces;
// using System.Collections.Generic;
// using apivent.Infrastructure.Models;

// namespace apivent.Application.Repositories
// {
//     public abstract class ControllerBaseRepository<T> : ControllerBase where T : class
//     {
//         private readonly IGenericRepository<T> repoServicio;  

//         public ControllerBaseRepository(IGenericRepository<T> _repoServicio)
//         {
//             repoServicio = _repoServicio;
//         }

//         [HttpPost]
//         public IActionResult PostCreate([FromBody] T record)
//         {
//             repoServicio.Add(record);
//             repoServicio.Save();
//             return Ok(record);
//         }

//         [HttpDelete("{id}")]
//         public IActionResult Delete(int id)
//         {
//             repoServicio.Delete(id);
//             if (repoServicio.Save() == 0)
//                 return BadRequest();

//             return Ok(id);    
//         }

//         [HttpGet("{id}")]
//         public IActionResult GetFind(int id)
//         {
//             var record = repoServicio.GetById(id);
//             if (record == null)
//                 return NotFound();

//             return Ok(record);
//         }

//         [HttpGet]
//         [Route("")]
//         public IActionResult Get() => Ok(repoServicio.Get());

//         [HttpPut("")]
//         public IActionResult PutUpdate([FromBody] T record)
//         {
//             repoServicio.Update(record);
//             if (repoServicio.Save() == 0)
//                 return BadRequest();
            
//             return Ok(record);
//         }
//     }
// }