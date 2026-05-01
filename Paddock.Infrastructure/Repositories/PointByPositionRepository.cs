using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;

namespace PaddockAPI.Infrastructure.Repositories;

public class PointByPositionRepository : IPointByPositionRepository
{
	private readonly AppDbContext _appDbContext;

	public PointByPositionRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<PointByPosition> GetPointByPosition(int id)
	{
		return await _appDbContext.PointByPositions.FirstOrDefaultAsync(p => p.Id == id);
	}

	public async Task<IEnumerable<PointByPosition>> GetPointByPositions()
	{
		return await _appDbContext.PointByPositions.ToListAsync();
	}

	public async Task<PointByPosition> AddPointByPosition(PointByPosition pointByPosition)
	{
		var res = await _appDbContext.PointByPositions.AddAsync(pointByPosition);


		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<PointByPosition> UpdatePointByPosition(PointByPosition pointByPosition)
	{
		var pp = await GetPointByPosition(pointByPosition.Id);

		pp.SeasonYear = pointByPosition.SeasonYear;
		pp.Points     = pointByPosition.Points;
		pp.Place      = pointByPosition.Place;

		await _appDbContext.SaveChangesAsync();
		return pp;
	}

	public async Task<bool> DeletePointByPosition(int id)
	{
		var pointByPosition = await GetPointByPosition(id);
		if (pointByPosition == null)
		{
			return false;
		}

		_appDbContext.Remove(pointByPosition);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
