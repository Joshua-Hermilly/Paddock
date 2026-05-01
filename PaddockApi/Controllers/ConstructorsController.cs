using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConstructorsController : ControllerBase
{
    private readonly IConstructorRepository _constructorRepository;

    public ConstructorsController(IConstructorRepository constructorRepository)
    {
        _constructorRepository = constructorRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ConstructorDto>> GetConstructor(int id)
    {
        var constructor = await _constructorRepository.GetConstructor(id);
        if (constructor == null)
        {
			return NotFound();
		}

		return Ok(constructor);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConstructorDto>>> GetConstructors()
    {
        var constructors = await _constructorRepository.GetConstructors();
        return Ok(constructors);
    }

    [HttpPost]
    public async Task<ActionResult<ConstructorDto>> PostConstructor([FromBody] ConstructorDto constructor)
    {
        Constructor constructorEntity = new Constructor
        {
            Name = constructor.Name,
			Nationality = constructor.Nationality
        };

		var created = await _constructorRepository.AddConstructor(constructorEntity);
        return CreatedAtAction(nameof(GetConstructor), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutConstructor([FromRoute] int id, [FromBody] Constructor constructor)
    {
        if (id != constructor.Id)
        {
            return BadRequest();
        }

        var updated = await _constructorRepository.UpdateConstructor(constructor);
        if (updated == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConstructor([FromRoute] int id)
    {
        var deleted = await _constructorRepository.DeleteConstructor(id);
        if (!deleted)
        {
			return NotFound();
		}
		return NoContent();
    }
}
