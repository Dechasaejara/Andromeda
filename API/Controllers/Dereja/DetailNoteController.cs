using Andromenda.API.Models;
using API.Models.Dereja;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Andromenda.API.Controllers.Dereja;
[ApiController]
[Route("api/[controller]")]
public class DetailNoteController : ControllerBase
{
    private readonly MyAppDbContext _context;
    public DetailNoteController(MyAppDbContext context)
    {
        _context = context;
    }
    #region Get All DetailNote
    [HttpGet]   // GET: api/DetailNote
    public async Task<ActionResult<IEnumerable<DetailNote>>> GetAllDetailNote()
    {
        try
        {
            var _data = await _context.DetailNotes.ToListAsync();
            return Ok(new ApiSuccessResponse().Data = _data);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Get Single DetailNote
    [HttpGet("{id}")] // GET: api/DetailNote/{id}
    public async Task<ActionResult<DetailNote>> GetSingleDetailNote(int id)
    {
        try
        {
            var _data = await _context.DetailNotes.FindAsync(id);
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
    #region Create DetailNote
    [HttpPost]   // POST: api/DetailNote
    public async Task<IActionResult> CreateDetailNote(DetailNote itemObj)
    {
        try
        {
            _context.DetailNotes.Add(itemObj);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSingleDetailNote), new { id = itemObj.Id }, itemObj);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Update DetailNote
    [HttpPut("{id}")] // PUT: api/DetailNote/{id}
    public async Task<IActionResult> UpdateDetailNote(int id, DetailNote itemObj)
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
    #region Delete DetailNote
    [HttpDelete("{id}")]  // DELETE: api/DetailNote/{id}
    public async Task<IActionResult> DeleteDetailNote(int id)
    {
        try
        {
            var _item = await _context.DetailNotes.FindAsync(id);
            if (_item == null)
                return NotFound(new ApiErrorResponse().Message = "Item Not Found");
            _context.DetailNotes.Remove(_item);
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