namespace PaddockAPI.Infrastructure.Repositories;

public interface IStandingConstructorRepository
{
	Task<StandingConstructor> GetStandingConstructor(int id);
	Task<IEnumerable<StandingConstructor>> GetStandingConstructors();
	Task<StandingConstructor> AddStandingConstructor(StandingConstructor standing);
	Task<StandingConstructor> UpdateStandingConstructor(StandingConstructor standing);
	Task<bool> DeleteStandingConstructor(int id);
}
