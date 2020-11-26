// using Microsoft.AspNetCore.Mvc;

// namespace Services.Logic.Repositories
// {
//     // https://www.growthaccelerationpartners.com/tech/implement-repository-pattern-net-core/    public abstract class ControllerBaseRepository<T, TRepository> : ControllerBase where T : class where TRepository : IGenericRepository<T>
//     {
//         protected readonly TRepository repoServicio;
//         public ControllerBaseRepository(TRepository  _repoServicio)
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