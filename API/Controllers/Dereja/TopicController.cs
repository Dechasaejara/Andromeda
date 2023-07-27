using Andromenda.API.Models;
using API.Models.Dereja;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Andromenda.API.Controllers.Dereja;
[ApiController]
[Route("api/[controller]")]
public class TopicController : ControllerBase
{
    private readonly MyAppDbContext _context;
    public TopicController(MyAppDbContext context)
    {
        _context = context;
    }
    #region Get All Topic
    [HttpGet]   // GET: api/Topic
    public async Task<ActionResult<IEnumerable<Topic>>> GetAllTopic()
    {
        try
        {
            var _data = await _context.Topics.ToListAsync();
            return Ok(new ApiSuccessResponse().Data = _data);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Get Single Topic
    [HttpGet("{id}")] // GET: api/Topic/{id}
    public async Task<ActionResult<Topic>> GetSingleTopic(int id)
    {
        try
        {
            var _data = await _context.Topics.FindAsync(id);
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
    #region Create Topic
    [HttpPost]   // POST: api/Topic
    public async Task<IActionResult> CreateTopic(Topic itemObj)
    {
        try
        {
            _context.Topics.Add(itemObj);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSingleTopic), new { id = itemObj.Id }, itemObj);
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiErrorResponse().Message = ex.Message);
        }
    }
    #endregion
    #region Update Topic
    [HttpPut("{id}")] // PUT: api/Topic/{id}
    public async Task<IActionResult> UpdateTopic(int id, Topic itemObj)
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
    #region Delete Topic
    [HttpDelete("{id}")]  // DELETE: api/Topic/{id}
    public async Task<IActionResult> DeleteTopic(int id)
    {
        try
        {
            var _item = await _context.Topics.FindAsync(id);
            if (_item == null)
                return NotFound(new ApiErrorResponse().Message = "Item Not Found");
            _context.Topics.Remove(_item);
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