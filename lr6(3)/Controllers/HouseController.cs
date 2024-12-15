using lr6_3_.Interfaces;
using lr6_3_.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HouseController : ControllerBase
{
    private readonly IHouseData _houseService;

    public HouseController(IHouseData houseService)
    {
        _houseService = houseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _houseService.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] House model)
    {
        var result = await _houseService.AddAsync(model);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] House model)
    {
        var result = await _houseService.UpdateAsync(id, model);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _houseService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}