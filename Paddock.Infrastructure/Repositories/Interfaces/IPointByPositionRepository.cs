namespace PaddockAPI.Infrastructure.Repositories;

public interface IPointByPositionRepository
{
	Task<PointByPosition> GetPointByPosition(int id);
	Task<IEnumerable<PointByPosition>> GetPointByPositions();
	Task<PointByPosition> AddPointByPosition(PointByPosition pointByPosition);
	Task<PointByPosition> UpdatePointByPosition(PointByPosition pointByPosition);
	Task<bool> DeletePointByPosition(int id);
}
