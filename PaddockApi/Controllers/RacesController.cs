using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RacesController : ControllerBase
{
    private readonly IRaceRepository _raceRepository;

    public RacesController(IRaceRepository raceRepository)
    {
        _raceRepository = raceRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Race>> GetRace(int id)
    {
        var race = await _raceRepository.GetRace(id);
        if (race == null)
            return NotFound();
        return Ok(race);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Race>>> GetRaces()
    {
        var races = await _raceRepository.GetRaces();
        return Ok(races);
    }

    [HttpPost]
    public async Task<ActionResult<Race>> PostRace([FromBody] Race race)
    {
        var created = await _raceRepository.AddRace(race);
        return CreatedAtAction(nameof(GetRace), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutRace([FromRoute] int id, [FromBody] Race race)
    {
        if (id != race.Id)
            return BadRequest();
        var updated = await _raceRepository.UpdateRace(race);
        if (updated == null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRace([FromRoute] int id)
    {
        var deleted = await _raceRepository.DeleteRace(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
