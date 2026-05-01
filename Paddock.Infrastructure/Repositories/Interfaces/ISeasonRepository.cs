namespace PaddockAPI.Infrastructure.Repositories;

public interface ISeasonRepository
{
	Task<Season> GetSeason(int id);
	Task<IEnumerable<Season>> GetSeasons();
	Task<Season> AddSeason(Season season);
	Task<bool> DeleteSeason(int id);
}
