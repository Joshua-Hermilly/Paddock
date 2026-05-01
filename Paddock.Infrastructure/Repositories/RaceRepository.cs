using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;
using System.ComponentModel.DataAnnotations;

namespace PaddockAPI.Infrastructure.Repositories;

public class RaceRepository : IRaceRepository
{
	private readonly AppDbContext _appDbContext;

	public RaceRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<Race> GetRace(int id)
	{
		return await _appDbContext.Races.FirstOrDefaultAsync(r => r.Id == id);
	}

	public async Task<IEnumerable<Race>> GetRaces()
	{
		return await _appDbContext.Races.ToListAsync();
	}

	public async Task<Race> AddRace(Race race)
	{
		var res = await _appDbContext.Races.AddAsync(race);


		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<Race> UpdateRace(Race race)
	{
		var rc = await GetRace(race.Id);

		rc.Round = race.Round;
		rc.Name  = race.Name;
		rc.Date  = race.Date; 

		await _appDbContext.SaveChangesAsync();
		return rc;
	}

	public async Task<bool> DeleteRace(int id)
	{
		var race = await GetRace(id);
		if (race == null)
		{
			return false;
		}

		_appDbContext.Remove(race);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
