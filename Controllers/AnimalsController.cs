using APBD5.Classes;
using APBD5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;
[ApiController]
[Route("animals")]
public class AnimalsController : ControllerBase
{
    private IMockDb _mockDb;

    public AnimalsController(IMockDb mockDb)
    {
        _mockDb = mockDb;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_mockDb.GetAll());
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_mockDb.Get(id));
    }
    [HttpPost]
    public IActionResult Add(Animal animal)
    {
        if (_mockDb.GetAll().FirstOrDefault(e => e.Id == animal.Id) is not null) 
            return Conflict();
        _mockDb.Add(animal);
        return Created();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _mockDb.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Replace(Animal animal, int id)
    {
        _mockDb.Replace(animal, id);
        return NoContent();
    }
}