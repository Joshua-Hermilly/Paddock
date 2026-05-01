using Microsoft.EntityFrameworkCore;
using PaddockAPI.Infrastructure.Database;

namespace PaddockAPI.Infrastructure.Repositories;

public class TrackRepository : ITrackRepository
{
	private readonly AppDbContext _appDbContext;

	public TrackRepository(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}


	public async Task<Track> GetTrack(int id)
	{
		return await _appDbContext.Tracks.FirstOrDefaultAsync(t => t.Id == id);
	}

	public async Task<IEnumerable<Track>> GetTracks()
	{
		return await _appDbContext.Tracks.ToListAsync();
	}

	public async Task<Track> AddTrack(Track track)
	{
		var res = await _appDbContext.Tracks.AddAsync(track);
		await _appDbContext.SaveChangesAsync();
		return res.Entity;
	}

	public async Task<Track> UpdateTrack(Track track)
	{
		var tc = await GetTrack(track.Id);

		tc.Name       = track.Name;
		tc.LocationId = track.LocationId;

		await _appDbContext.SaveChangesAsync();
		return tc;
	}

	public async Task<bool> DeleteTrack(int id)
	{
		var track = await GetTrack(id);
		if (track == null)
		{
			return false;
		}

		_appDbContext.Remove(track);
		await _appDbContext.SaveChangesAsync();
		return true;
	}
}
