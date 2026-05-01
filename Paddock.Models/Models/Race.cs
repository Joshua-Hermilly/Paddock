using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Race
{
	[Key]
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("round")]
	public int Round { get; set; }

	[Required, StringLength(150, MinimumLength = 3)]
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	[Required, DataType(DataType.Date)]
	[JsonPropertyName("date")]
	public DateTime Date { get; set; }

	/*------------------------------------*/
	/* Join                               */
	/*------------------------------------*/
	[JsonPropertyName("trackId")]
	public int TrackId { get; set; }

	[JsonPropertyName("track")]
	public Track Track { get; set; } = null!;

	[JsonPropertyName("seasonYear")]
	public int SeasonYear { get; set; }

	[JsonPropertyName("season")]
	public Season Season { get; set; } = null!;

	[JsonPropertyName("positions")]
	public ICollection<Position> Positions { get; set; } = [];

	[JsonPropertyName("standingsDrivers")]
	public ICollection<StandingDriver> StandingsDrivers { get; set; } = [];

	[JsonPropertyName("standingsConstructors")]
	public ICollection<StandingConstructor> StandingsConstructors { get; set; } = [];
}