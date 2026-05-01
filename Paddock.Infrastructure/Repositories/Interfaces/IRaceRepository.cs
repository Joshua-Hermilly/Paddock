namespace PaddockAPI.Infrastructure.Repositories;

public interface IRaceRepository
{
	Task<Race> GetRace(int id);
	Task<IEnumerable<Race>> GetRaces();
	Task<Race> AddRace(Race race);
	Task<Race> UpdateRace(Race race);
	Task<bool> DeleteRace(int id);
}
