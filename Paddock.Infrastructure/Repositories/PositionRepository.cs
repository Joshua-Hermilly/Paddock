using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;

namespace PaddockAPI.Infrastructure.Repositories;

public class PositionRepository : IPositionRepository
{
	private readonly AppDbContext _appDbContext;

	public PositionRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<Position> GetPosition(int id)
	{
		return await _appDbContext.Positions.FirstOrDefaultAsync(p => p.Id == id);
	}

	public async Task<IEnumerable<Position>> GetPositions()
	{
		return await _appDbContext.Positions.ToListAsync();
	}

	public async Task<Position> AddPosition(Position position)
	{
		var res = await _appDbContext.Positions.AddAsync(position);


		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<Position> UpdatePosition(Position position)
	{
		var pt = await GetPosition(position.Id);

		pt.StartingGrid = position.StartingGrid;
		pt.FinishGrid   = position.FinishGrid;
		pt.Status       = position.Status;
		pt.Points       = position.Points;
		pt.Time         = position.Time;
		pt.IsFastestLap = position.IsFastestLap;

		await _appDbContext.SaveChangesAsync();
		return pt;
	}

	public async Task<bool> DeletePosition(int id)
	{
		var position = await GetPosition(id);
		if (position == null)
		{
			return false;
		}

		_appDbContext.Remove(position);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
