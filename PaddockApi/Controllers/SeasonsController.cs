using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeasonsController : ControllerBase
{
    private readonly ISeasonRepository _seasonRepository;

    public SeasonsController(ISeasonRepository seasonRepository)
    {
        _seasonRepository = seasonRepository;
    }

    [HttpGet("{year}")]
    public async Task<ActionResult<Season>> GetSeason(int year)
    {
        var season = await _seasonRepository.GetSeason(year);
        if (season == null)
            return NotFound();
        return Ok(season);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Season>>> GetSeasons()
    {
        var seasons = await _seasonRepository.GetSeasons();
        return Ok(seasons);
    }

    [HttpPost]
    public async Task<ActionResult<Season>> PostSeason([FromBody] Season season)
    {
        var created = await _seasonRepository.AddSeason(season);
        return CreatedAtAction(nameof(GetSeason), new { year = created.Year }, created);
    }

    [HttpDelete("{year}")]
    public async Task<IActionResult> DeleteSeason([FromRoute] int year)
    {
        var deleted = await _seasonRepository.DeleteSeason(year);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
