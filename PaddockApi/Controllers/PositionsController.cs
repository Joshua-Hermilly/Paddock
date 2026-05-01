using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionsController : ControllerBase
{
    private readonly IPositionRepository _positionRepository;

    public PositionsController(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Position>> GetPosition(int id)
    {
        var position = await _positionRepository.GetPosition(id);
        if (position == null)
            return NotFound();
        return Ok(position);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
    {
        var positions = await _positionRepository.GetPositions();
        return Ok(positions);
    }

    [HttpPost]
    public async Task<ActionResult<Position>> PostPosition([FromBody] Position position)
    {
        var created = await _positionRepository.AddPosition(position);
        return CreatedAtAction(nameof(GetPosition), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPosition([FromRoute] int id, [FromBody] Position position)
    {
        if (id != position.Id)
            return BadRequest();
        var updated = await _positionRepository.UpdatePosition(position);
        if (updated == null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePosition([FromRoute] int id)
    {
        var deleted = await _positionRepository.DeletePosition(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
