using Andromenda.API.Models;
using API.Models.Dereja;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Andromenda.API.Controllers.Dereja;
[ApiController]
[Route("api/[controller]")]
public class CheatSheetController : ControllerBase
{
    private readonly MyAppDbContext _context;
    public CheatSheetController(MyAppDbContext context)
    {
        _context = context;
    }
    #region Get All CheatSheet
    [HttpGet]   // GET: api/CheatSheet
    public async Task<ActionResult<IEnumerable<CheatSheet>>> GetAllCheatSheet()
    {
        try
        {
            var _data = await _context.CheatSheets.ToListAsync();
            return Ok(new ApiSuccessResponse().Data = _data);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Get Single CheatSheet
    [HttpGet("{id}")] // GET: api/CheatSheet/{id}
    public async Task<ActionResult<CheatSheet>> GetSingleCheatSheet(int id)
    {
        try
        {
            var _data = await _context.CheatSheets.FindAsync(id);
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
    #region Create CheatSheet
    [HttpPost]   // POST: api/CheatSheet
    public async Task<IActionResult> CreateCheatSheet(CheatSheet itemObj)
    {
        try
        {
            _context.CheatSheets.Add(itemObj);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSingleCheatSheet), new { id = itemObj.Id }, itemObj);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Update CheatSheet
    [HttpPut("{id}")] // PUT: api/CheatSheet/{id}
    public async Task<IActionResult> UpdateCheatSheet(int id, CheatSheet itemObj)
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
    #region Delete CheatSheet
    [HttpDelete("{id}")]  // DELETE: api/CheatSheet/{id}
    public async Task<IActionResult> DeleteCheatSheet(int id)
    {
        try
        {
            var _item = await _context.CheatSheets.FindAsync(id);
            if (_item == null)
                return NotFound(new ApiErrorResponse().Message = "Item Not Found");
            _context.CheatSheets.Remove(_item);
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