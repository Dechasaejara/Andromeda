using Andromenda.API.Models;
using API.Models.Dereja;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Andromenda.API.Controllers.Dereja;
[ApiController]
[Route("api/[controller]")]
public class SolutionController : ControllerBase
{
    private readonly MyAppDbContext _context;
    public SolutionController(MyAppDbContext context)
    {
        _context = context;
    }
    #region Get All Solution
    [HttpGet]   // GET: api/Solution
    public async Task<ActionResult<IEnumerable<Solution>>> GetAllSolution()
    {
        try
        {
            var _data = await _context.Solutions.ToListAsync();
            return Ok(new ApiSuccessResponse().Data = _data);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Get Single Solution
    [HttpGet("{id}")] // GET: api/Solution/{id}
    public async Task<ActionResult<Solution>> GetSingleSolution(int id)
    {
        try
        {
            var _data = await _context.Solutions.FindAsync(id);
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
    #region Create Solution
    [HttpPost]   // POST: api/Solution
    public async Task<IActionResult> CreateSolution(Solution itemObj)
    {
        try
        {
            _context.Solutions.Add(itemObj);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSingleSolution), new { id = itemObj.Id }, itemObj);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Update Solution
    [HttpPut("{id}")] // PUT: api/Solution/{id}
    public async Task<IActionResult> UpdateSolution(int id, Solution itemObj)
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
    #region Delete Solution
    [HttpDelete("{id}")]  // DELETE: api/Solution/{id}
    public async Task<IActionResult> DeleteSolution(int id)
    {
        try
        {
            var _item = await _context.Solutions.FindAsync(id);
            if (_item == null)
                return NotFound(new ApiErrorResponse().Message = "Item Not Found");
            _context.Solutions.Remove(_item);
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