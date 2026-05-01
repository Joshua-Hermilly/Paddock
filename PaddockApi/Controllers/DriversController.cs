using Microsoft.AspNetCore.Mvc;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly IDriverRepository _driverRepository;

    public DriversController(IDriverRepository context)
    {
			_driverRepository = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> GetDriver(int id)
    {
        var driver = await _driverRepository.GetDriver(id);

        if (driver == null) 
        { 
            return NotFound();
		}

		return Ok(driver);
	}

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
    {
        var drivers = await _driverRepository.GetDrivers();
        return Ok(drivers);
	}

    [HttpPost]
    public async Task<ActionResult<Driver>> PostDriver([FromBody] Driver driver)
    {
        var createdDriver = await _driverRepository.AddDriver(driver);
        return CreatedAtAction(nameof(GetDriver), new { id = createdDriver.Id }, createdDriver);
    }
     
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDriver([FromRoute] int id, [FromBody] Driver driver)
    {
        if (id != driver.Id)
        {
            return BadRequest();
        }
        var updatedDriver = await _driverRepository.UpdateDriver(driver);
        if (updatedDriver == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver([FromRoute] int id)
    {
        var deleted = await _driverRepository.DeleteDriver(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
	}
}