using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;

namespace PaddockAPI.Infrastructure.Repositories;

public class StandingConstructorRepository : IStandingConstructorRepository
{
	private readonly AppDbContext _appDbContext;

	public StandingConstructorRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<StandingConstructor> GetStandingConstructor(int id)
	{
		return await _appDbContext.StandingConstructors.FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<IEnumerable<StandingConstructor>> GetStandingConstructors()
	{
		return await _appDbContext.StandingConstructors.ToListAsync();
	}

	public async Task<StandingConstructor> AddStandingConstructor(StandingConstructor standing)
	{
		var res = await _appDbContext.StandingConstructors.AddAsync(standing);


		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<StandingConstructor> UpdateStandingConstructor(StandingConstructor standing)
	{
		var st = await GetStandingConstructor(standing.Id);

		st.Rank          = standing.Rank;
		st.Points        = standing.Points;
		st.Wins          = standing.Wins;
		st.ConstructorId = standing.ConstructorId;
		st.SeasonYear    = standing.SeasonYear;

		await _appDbContext.SaveChangesAsync();
		return st;
	}

	public async Task<bool> DeleteStandingConstructor(int id)
	{
		var standing = await GetStandingConstructor(id);
		if (standing == null)
		{
			return false;
		}

		_appDbContext.Remove(standing);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
