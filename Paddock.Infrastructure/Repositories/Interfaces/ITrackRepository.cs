namespace PaddockAPI.Infrastructure.Repositories;

public interface ITrackRepository
{
	Task<Track> GetTrack(int id);
	Task<IEnumerable<Track>> GetTracks();
	Task<Track> AddTrack(Track track);
	Task<Track> UpdateTrack(Track track);
	Task<bool> DeleteTrack(int id);
}
