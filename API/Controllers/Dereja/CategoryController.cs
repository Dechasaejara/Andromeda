using Andromenda.API.Models;
using API.Models.Dereja;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Andromenda.API.Controllers.Dereja;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly MyAppDbContext _context;
    public CategoryController(MyAppDbContext context)
    {
        _context = context;
    }
    #region Get All Category
    [HttpGet]   // GET: api/Category
    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
    {
        try
        {
            var _data = await _context.Categorys.ToListAsync();
            return Ok(new ApiSuccessResponse().Data = _data);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Get Single Category
    [HttpGet("{id}")] // GET: api/Category/{id}
    public async Task<ActionResult<Category>> GetSingleCategory(int id)
    {
        try
        {
            var _data = await _context.Categorys.FindAsync(id);
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
    #region Create Category
    [HttpPost]   // POST: api/Category
    public async Task<IActionResult> CreateCategory(Category itemObj)
    {
        try
        {
            _context.Categorys.Add(itemObj);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSingleCategory), new { id = itemObj.Id }, itemObj);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Update Category
    [HttpPut("{id}")] // PUT: api/Category/{id}
    public async Task<IActionResult> UpdateCategory(int id, Category itemObj)
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
    #region Delete Category
    [HttpDelete("{id}")]  // DELETE: api/Category/{id}
    public async Task<IActionResult> DeleteCategory(int id)
    {
        try
        {
            var _item = await _context.Categorys.FindAsync(id);
            if (_item == null)
                return NotFound(new ApiErrorResponse().Message = "Item Not Found");
            _context.Categorys.Remove(_item);
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