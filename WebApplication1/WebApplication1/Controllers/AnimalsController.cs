
namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1;

[ApiController]
[Route("api/[controller]")]

public class AnimalsController : ControllerBase
{

    private static List<Animal> _animals = new List<Animal>
    {
        new Animal {Id = 1, Name = "Burza",Category = "Dog",Weight = 22.5,FurColor = "Black"},
        new Animal {Id = 2, Name = "Puszek",Category = "Cat",Weight = 11,FurColor = "White"}
    };


    [HttpGet]
    public ActionResult<List<Animal>> GetAllAnimals()
    {
        return _animals;
    }




    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }

        return animal;
    }

    
    
    [HttpPost]
    public ActionResult<Animal> AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    
    
    [HttpPut("{id}")]
    public ActionResult UpdateAnimal(int id, Animal animal)
    {
        var index = _animals.FindIndex(a => a.Id == id);
        if (index == -1)
        {
            return NotFound();
        }
        _animals[index] = animal;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAnimal(int id)
    {
        var index = _animals.FindIndex(a => a.Id == id);
        if (index == -1 )
        {
            return NotFound();
        }
        _animals.RemoveAt(index);
        return NoContent();
    }
}