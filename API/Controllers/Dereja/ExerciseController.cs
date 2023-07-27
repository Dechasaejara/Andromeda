using Andromenda.API.Models;
using API.Models.Dereja;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Andromenda.API.Controllers.Dereja;
[ApiController]
[Route("api/[controller]")]
public class ExerciseController : ControllerBase
{
    private readonly MyAppDbContext _context;
    public ExerciseController(MyAppDbContext context)
    {
        _context = context;
    }
    #region Get All Exercise
    [HttpGet]   // GET: api/Exercise
    public async Task<ActionResult<IEnumerable<Exercise>>> GetAllExercise()
    {
        try
        {
            var _data = await _context.Exercises.ToListAsync();
            return Ok(new ApiSuccessResponse().Data = _data);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Get Single Exercise
    [HttpGet("{id}")] // GET: api/Exercise/{id}
    public async Task<ActionResult<Exercise>> GetSingleExercise(int id)
    {
        try
        {
            var _data = await _context.Exercises.FindAsync(id);
            if (_data != null)
            {
                return Ok(new ApiSuccessResponse().Data = _data);
            }
            return NotFound(new ApiErrorResponse() { Message = "Not Found", StatusCode = 404 });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Create Exercise
    [HttpPost]   // POST: api/Exercise
    public async Task<IActionResult> CreateExercise(Exercise itemObj)
    {
        try
        {
            _context.Exercises.Add(itemObj);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSingleExercise), new { id = itemObj.Id }, itemObj);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Update Exercise
    [HttpPut("{id}")] // PUT: api/Exercise/{id}
    public async Task<IActionResult> UpdateExercise(int id, Exercise itemObj)
    {
        if (id != itemObj.Id)
            return BadRequest(new ApiErrorResponse().Message = "Item Not Found");
        try
        {
            _context.Entry(itemObj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new ApiSuccessResponse());
        }
        catch (DbUpdateConcurrencyException exx)
        {
            return BadRequest(new ApiErrorResponse().Message = exx.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Delete Exercise
    [HttpDelete("{id}")]  // DELETE: api/Exercise/{id}
    public async Task<IActionResult> DeleteExercise(int id)
    {
        try
        {
            var _item = await _context.Exercises.FindAsync(id);
            if (_item == null)
                return NotFound(new ApiErrorResponse().Message = "Item Not Found");
            _context.Exercises.Remove(_item);
            await _context.SaveChangesAsync();
            return Ok(new ApiSuccessResponse());
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
}