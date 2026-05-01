using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PointByPositionsController : ControllerBase
{
    private readonly IPointByPositionRepository _pointByPositionRepository;

    public PointByPositionsController(IPointByPositionRepository pointByPositionRepository)
    {
        _pointByPositionRepository = pointByPositionRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PointByPosition>> GetPointByPosition(int id)
    {
        var pointByPosition = await _pointByPositionRepository.GetPointByPosition(id);
        if (pointByPosition == null)
            return NotFound();
        return Ok(pointByPosition);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PointByPosition>>> GetPointByPositions()
    {
        var pointByPositions = await _pointByPositionRepository.GetPointByPositions();
        return Ok(pointByPositions);
    }

    [HttpPost]
    public async Task<ActionResult<PointByPosition>> PostPointByPosition([FromBody] PointByPosition pointByPosition)
    {
        var created = await _pointByPositionRepository.AddPointByPosition(pointByPosition);
        return CreatedAtAction(nameof(GetPointByPosition), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPointByPosition([FromRoute] int id, [FromBody] PointByPosition pointByPosition)
    {
        if (id != pointByPosition.Id)
            return BadRequest();
        var updated = await _pointByPositionRepository.UpdatePointByPosition(pointByPosition);
        if (updated == null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePointByPosition([FromRoute] int id)
    {
        var deleted = await _pointByPositionRepository.DeletePointByPosition(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
