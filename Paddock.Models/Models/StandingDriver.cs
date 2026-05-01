using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class StandingDriver
{
	[Key]
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("rank")]
	public int Rank { get; set; }

	[JsonPropertyName("points")]
	public double Points { get; set; }

	[JsonPropertyName("wins")]
	public int Wins { get; set; }
	/*------------------------------------*/
	/* Join                               */
	/*------------------------------------*/
	[JsonPropertyName("driverId")]
	public int DriverId { get; set; }

	[JsonPropertyName("driver")]
	public Driver Driver { get; set; } = null!;

	[JsonPropertyName("seasonYear")]
	public int SeasonYear { get; set; }

	[JsonPropertyName("season")]
	public Season Season { get; set; } = null!;
}