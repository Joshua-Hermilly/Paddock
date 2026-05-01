using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StandingDriversController : ControllerBase
{
    private readonly IStandingDriverRepository _standingDriverRepository;

    public StandingDriversController(IStandingDriverRepository standingDriverRepository)
    {
        _standingDriverRepository = standingDriverRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StandingDriver>> GetStandingDriver(int id)
    {
        var standing = await _standingDriverRepository.GetStandingDriver(id);
        if (standing == null)
            return NotFound();
        return Ok(standing);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StandingDriver>>> GetStandingDrivers()
    {
        var standings = await _standingDriverRepository.GetStandingDrivers();
        return Ok(standings);
    }

    [HttpPost]
    public async Task<ActionResult<StandingDriver>> PostStandingDriver([FromBody] StandingDriver standing)
    {
        var created = await _standingDriverRepository.AddStandingDriver(standing);
        return CreatedAtAction(nameof(GetStandingDriver), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStandingDriver([FromRoute] int id, [FromBody] StandingDriver standing)
    {
        if (id != standing.Id)
            return BadRequest();
        var updated = await _standingDriverRepository.UpdateStandingDriver(standing);
        if (updated == null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStandingDriver([FromRoute] int id)
    {
        var deleted = await _standingDriverRepository.DeleteStandingDriver(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
