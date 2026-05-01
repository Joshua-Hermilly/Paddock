using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;

namespace PaddockAPI.Infrastructure.Repositories;

public class ConstructorRepository : IConstructorRepository
{
	private readonly AppDbContext _appDbContext;

	public ConstructorRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<Constructor> GetConstructor(int id)
	{
		return await _appDbContext.Constructors.FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<IEnumerable<Constructor>> GetConstructors()
	{
		return await _appDbContext.Constructors.ToListAsync();
	}

	public async Task<Constructor> AddConstructor(Constructor constructor)
	{
		var res = await _appDbContext.Constructors.AddAsync(constructor);
		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<Constructor> UpdateConstructor(Constructor constructor)
	{
		var ct = await GetConstructor(constructor.Id);

		ct.Name        = constructor.Name;
		ct.Nationality = constructor.Nationality;
		ct.LocationId  = constructor.LocationId;

		await _appDbContext.SaveChangesAsync();
		return ct;
	}

	public async Task<bool> DeleteConstructor(int id)
	{
		var constructor = await GetConstructor(id);
		if (constructor == null)
		{
			return false;
		}
		_appDbContext.Constructors.Remove(constructor);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
