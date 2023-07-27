using Andromenda.API.Models;
using API.Models.Dereja;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Andromenda.API.Controllers.Dereja;
[ApiController]
[Route("api/[controller]")]
public class AppConstantController : ControllerBase
{
    private readonly MyAppDbContext _context;
    public AppConstantController(MyAppDbContext context)
    {
        _context = context;
    }
    #region Get All AppConstant
    [HttpGet]   // GET: api/AppConstant
    public async Task<ActionResult<IEnumerable<AppConstant>>> GetAllAppConstant()
    {
        try
        {
            var _data = await _context.AppConstants.ToListAsync();
            return Ok(new ApiSuccessResponse().Data = _data);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Get Single AppConstant
    [HttpGet("{id}")] // GET: api/AppConstant/{id}
    public async Task<ActionResult<AppConstant>> GetSingleAppConstant(int id)
    {
        try
        {
            var _data = await _context.AppConstants.FindAsync(id);
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
    #region Create AppConstant
    [HttpPost]   // POST: api/AppConstant
    public async Task<IActionResult> CreateAppConstant(AppConstant itemObj)
    {
        try
        {
            _context.AppConstants.Add(itemObj);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSingleAppConstant), new { id = itemObj.Id }, itemObj);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Update AppConstant
    [HttpPut("{id}")] // PUT: api/AppConstant/{id}
    public async Task<IActionResult> UpdateAppConstant(int id, AppConstant itemObj)
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
    #region Delete AppConstant
    [HttpDelete("{id}")]  // DELETE: api/AppConstant/{id}
    public async Task<IActionResult> DeleteAppConstant(int id)
    {
        try
        {
            var _item = await _context.AppConstants.FindAsync(id);
            if (_item == null)
                return NotFound(new ApiErrorResponse().Message = "Item Not Found");
            _context.AppConstants.Remove(_item);
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