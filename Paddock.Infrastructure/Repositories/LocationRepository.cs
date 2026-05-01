using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;

namespace PaddockAPI.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
	private readonly AppDbContext _appDbContext;

	public LocationRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<Location> GetLocation(int id)
	{
		return await _appDbContext.Locations.FirstOrDefaultAsync(l => l.Id == id);
	}

	public async Task<IEnumerable<Location>> GetLocations()
	{
		return await _appDbContext.Locations.ToListAsync();
	}

	public async Task<Location> AddLocation(Location location)
	{
		var res = await _appDbContext.Locations.AddAsync(location);


		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<Location> UpdateLocation(Location location)
	{
		var lc = await GetLocation(location.Id);

		lc.Country   = location.Country;
		lc.Locality  = location.Locality;
		lc.Latitude  = location.Latitude;
		lc.Longitude = location.Longitude;

		await _appDbContext.SaveChangesAsync();
		return lc;
	}

	public async Task<bool> DeleteLocation(int id)
	{
		var location = await GetLocation(id);
		if (location == null)
		{
			return false;
		}

		_appDbContext.Remove(location);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
