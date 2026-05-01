namespace PaddockAPI.Infrastructure.Repositories;

public interface IConstructorRepository
{
	Task<Constructor> GetConstructor(int id);
	Task<IEnumerable<Constructor>> GetConstructors();
	Task<Constructor> AddConstructor(Constructor constructor);
	Task<Constructor> UpdateConstructor(Constructor constructor);
	Task<bool> DeleteConstructor(int id);
}
