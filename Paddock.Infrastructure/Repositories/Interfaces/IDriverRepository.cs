namespace PaddockAPI.Infrastructure.Repositories;

public interface IDriverRepository
{
	Task<Driver> GetDriver(int id);
	Task<IEnumerable<Driver>> GetDrivers();
	Task<Driver> AddDriver(Driver driver);
	Task<Driver> UpdateDriver(Driver driver);
	Task<bool> DeleteDriver(int id);
}
