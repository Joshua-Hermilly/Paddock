using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationRepository _locationRepository;

    public LocationsController(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Location>> GetLocation(int id)
    {
        var location = await _locationRepository.GetLocation(id);
        if (location == null)
            return NotFound();
        return Ok(location);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
    {
        var locations = await _locationRepository.GetLocations();
        return Ok(locations);
    }

    [HttpPost]
    public async Task<ActionResult<Location>> PostLocation([FromBody] Location location)
    {
        var created = await _locationRepository.AddLocation(location);
        return CreatedAtAction(nameof(GetLocation), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLocation([FromRoute] int id, [FromBody] Location location)
    {
        if (id != location.Id)
            return BadRequest();
        var updated = await _locationRepository.UpdateLocation(location);
        if (updated == null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation([FromRoute] int id)
    {
        var deleted = await _locationRepository.DeleteLocation(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
