namespace PaddockAPI.Infrastructure.Repositories;

public interface IPositionRepository
{
	Task<Position> GetPosition(int id);
	Task<IEnumerable<Position>> GetPositions();
	Task<Position> AddPosition(Position position);
	Task<Position> UpdatePosition(Position position);
	Task<bool> DeletePosition(int id);
}
