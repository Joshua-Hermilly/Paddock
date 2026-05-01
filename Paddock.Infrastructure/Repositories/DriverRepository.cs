using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;

namespace PaddockAPI.Infrastructure.Repositories;

public class DriverRepository : IDriverRepository
{
	private readonly AppDbContext _appDbContext;

	public DriverRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<Driver> GetDriver(int id)
	{
		return await _appDbContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
	}

	public async Task<IEnumerable<Driver>> GetDrivers()
	{
		return await _appDbContext.Drivers.ToListAsync();
	}

	public async Task<Driver> AddDriver(Driver driver)
	{
		var res = await _appDbContext.Drivers.AddAsync(driver);
		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<Driver> UpdateDriver(Driver driver)
	{
		var dv = await GetDriver(driver.Id);

		dv.Number        = driver.Number;
		dv.Code          = driver.Code;
		dv.Firstname     = driver.Firstname;
		dv.Lastname      = driver.Lastname;
		dv.DateOfBirth   = driver.DateOfBirth;
		dv.Nationality   = driver.Nationality;
		dv.ConstructorId = driver.ConstructorId;

		await _appDbContext.SaveChangesAsync();
		return dv;
	}

	public async Task<bool> DeleteDriver(int id)
	{
		var driver = await GetDriver(id);
		if (driver == null)
		{
			return false;
		}

		_appDbContext.Remove(driver);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
