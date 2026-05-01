using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;

namespace PaddockAPI.Infrastructure.Repositories;

public class SeasonRepository : ISeasonRepository
{
	private readonly AppDbContext _appDbContext;

	public SeasonRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<Season> GetSeason(int id)
	{
		return await _appDbContext.Seasons.FirstOrDefaultAsync(s => s.Year == id);
	}

	public async Task<IEnumerable<Season>> GetSeasons()
	{
		return await _appDbContext.Seasons.ToListAsync();
	}

	public async Task<Season> AddSeason(Season season)
	{
		var res = await _appDbContext.Seasons.AddAsync(season);


		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<bool> DeleteSeason(int id)
	{
		var season = await GetSeason(id);
		if (season == null)
		{
			return false;
		}

		_appDbContext.Remove(season);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
