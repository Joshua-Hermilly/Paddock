namespace PaddockAPI.Infrastructure.Repositories;

public interface ILocationRepository
{
	Task<Location> GetLocation(int id);
	Task<IEnumerable<Location>> GetLocations();
	Task<Location> AddLocation(Location location);
	Task<Location> UpdateLocation(Location location);
	Task<bool> DeleteLocation(int id);
}
