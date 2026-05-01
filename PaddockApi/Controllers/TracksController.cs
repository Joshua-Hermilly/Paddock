using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TracksController : ControllerBase
{
    private readonly ITrackRepository _trackRepository;

    public TracksController(ITrackRepository trackRepository)
    {
        _trackRepository = trackRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Track>> GetTrack(int id)
    {
        var track = await _trackRepository.GetTrack(id);
        if (track == null)
            return NotFound();
        return Ok(track);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
    {
        var tracks = await _trackRepository.GetTracks();
        return Ok(tracks);
    }

    [HttpPost]
    public async Task<ActionResult<Track>> PostTrack([FromBody] Track track)
    {
        var created = await _trackRepository.AddTrack(track);
        return CreatedAtAction(nameof(GetTrack), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTrack([FromRoute] int id, [FromBody] Track track)
    {
        if (id != track.Id)
            return BadRequest();
        var updated = await _trackRepository.UpdateTrack(track);
        if (updated == null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrack([FromRoute] int id)
    {
        var deleted = await _trackRepository.DeleteTrack(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
