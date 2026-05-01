using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;

namespace PaddockAPI.Infrastructure.Repositories;

public class StandingDriverRepository : IStandingDriverRepository
{
	private readonly AppDbContext _appDbContext;

	public StandingDriverRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<StandingDriver> GetStandingDriver(int id)
	{
		return await _appDbContext.StandingDrivers.FirstOrDefaultAsync(s => s.Id == id);
	}

	public async Task<IEnumerable<StandingDriver>> GetStandingDrivers()
	{
		return await _appDbContext.StandingDrivers.ToListAsync();
	}

	public async Task<StandingDriver> AddStandingDriver(StandingDriver standing)
	{
		var res = await _appDbContext.StandingDrivers.AddAsync(standing);


		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<StandingDriver> UpdateStandingDriver(StandingDriver standing)
	{
		var st = await GetStandingDriver(standing.Id);
		
		st.Rank          = standing.Rank;
		st.Points        = standing.Points;
		st.Wins          = standing.Wins;
		st.DriverId      = standing.DriverId;
		st.SeasonYear    = standing.SeasonYear;

		await _appDbContext.SaveChangesAsync();
		return st;
	}

	public async Task<bool> DeleteStandingDriver(int id)
	{
		var standing = await GetStandingDriver(id);
		if (standing == null)
		{
			return false;
		}

		_appDbContext.Remove(standing);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
