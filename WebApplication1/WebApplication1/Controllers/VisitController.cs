using Microsoft.AspNetCore.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class VisitController : ControllerBase
{
    private static List<Visit> _visits = new List<Visit>
    {
        new Visit { Id = 1, AnimalId = 1, DateOfVisit = DateTime.Now, Description = "Odrobaczanie", Cost = 300.0 },
        new Visit {Id = 2, AnimalId = 2, DateOfVisit = DateTime.Now.AddHours(5), Description = "Szczepienie", Cost = 150.0}
    };


    [HttpGet]
    public ActionResult<List<Visit>> GetAllVisits()
    {
        return _visits;
    }

    [HttpGet("{id}")]
    public ActionResult<Visit> GetVisit(int id)
    {
        var visit = _visits.FirstOrDefault(v => v.Id == id);
        if (visit == null)
        {
            return NotFound();
        }

        return visit;
    }

    [HttpPost]
    public ActionResult<Visit> AddVisit(Visit visit)
    {
        _visits.Add(visit);
        return CreatedAtAction(nameof(GetVisit), new { id = visit.Id }, visit);
    }

    [HttpGet("byAnimalId/{animalId}")]
    public ActionResult<List<Visit>> GetVisitsByAnimalId(int animalId)
    {
        var visits = _visits.Where(v => v.AnimalId == animalId).ToList();
        if (!visits.Any())
        {
            return NotFound();
        }

        return visits;
    }


}