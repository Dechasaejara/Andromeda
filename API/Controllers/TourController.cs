using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
namespace API.Controllers;

[ApiController]
[Route("api/tours")]
public class TourController : ControllerBase
{
    private readonly MyAppDbContext _context;

    public TourController(MyAppDbContext context)
    {
        _context = context;
    }

    // GET: api/tours
    [HttpGet]
    public async Task<IActionResult> GetTours()
    {
        var tours = await _context.Tours.ToListAsync();
        return Ok(tours);
    }

    // GET: api/tours/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTour(int id)
    {
        var tour = await _context.Tours.FindAsync(id);

        if (tour == null)
        {
            return NotFound();
        }

        return Ok(tour);
    }

    // POST: api/tours
    [HttpPost]
    public async Task<IActionResult> CreateTour(Tour tour)
    {
        _context.Tours.Add(tour);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTour), new { id = tour.Id }, tour);
    }

    // PUT: api/tours/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTour(int id, Tour tour)
    {
        if (id != tour.Id)
        {
            return BadRequest();
        }

        _context.Entry(tour).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TourExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/tours/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTour(int id)
    {
        var tour = await _context.Tours.FindAsync(id);

        if (tour == null)
        {
            return NotFound();
        }

        _context.Tours.Remove(tour);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TourExists(int id)
    {
        return _context.Tours.Any(e => e.Id == id);
    }
}