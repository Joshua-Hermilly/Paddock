using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StandingConstructorsController : ControllerBase
{
    private readonly IStandingConstructorRepository _standingConstructorRepository;

    public StandingConstructorsController(IStandingConstructorRepository standingConstructorRepository)
    {
        _standingConstructorRepository = standingConstructorRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StandingConstructor>> GetStandingConstructor(int id)
    {
        var standing = await _standingConstructorRepository.GetStandingConstructor(id);
        if (standing == null)
            return NotFound();
        return Ok(standing);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StandingConstructor>>> GetStandingConstructors()
    {
        var standings = await _standingConstructorRepository.GetStandingConstructors();
        return Ok(standings);
    }

    [HttpPost]
    public async Task<ActionResult<StandingConstructor>> PostStandingConstructor([FromBody] StandingConstructor standing)
    {
        var created = await _standingConstructorRepository.AddStandingConstructor(standing);
        return CreatedAtAction(nameof(GetStandingConstructor), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStandingConstructor([FromRoute] int id, [FromBody] StandingConstructor standing)
    {
        if (id != standing.Id)
            return BadRequest();
        var updated = await _standingConstructorRepository.UpdateStandingConstructor(standing);
        if (updated == null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStandingConstructor([FromRoute] int id)
    {
        var deleted = await _standingConstructorRepository.DeleteStandingConstructor(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
