namespace PaddockAPI.Infrastructure.Repositories;

public interface IStandingDriverRepository
{
	Task<StandingDriver> GetStandingDriver(int id);
	Task<IEnumerable<StandingDriver>> GetStandingDrivers();
	Task<StandingDriver> AddStandingDriver(StandingDriver standing);
	Task<StandingDriver> UpdateStandingDriver(StandingDriver standing);
	Task<bool> DeleteStandingDriver(int id);
}
