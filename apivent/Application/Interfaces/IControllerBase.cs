using Microsoft.AspNetCore.Mvc;

namespace apivent.Application.Interfaces
{
    public interface IControllerBase<T> where T : class
    {
        IActionResult Get();
        IActionResult GetFind(int id);
        IActionResult PostCreate([FromBody] T record);
        IActionResult PutUpdate(int id, [FromBody] T record);
        IActionResult Delete(int id);
    }
}