using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

public class Position
{
	[Key]
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("startingGrid")]
	public int StartingGrid { get; set; }

	[JsonPropertyName("finishGrid")]
	public int FinishGrid { get; set; }

	[JsonPropertyName("status")]
	public string Status { get; set; } = "";

	[JsonPropertyName("points")]
	public double Points { get; set; }
	
	[JsonPropertyName("time")]
	public string Time { get; set; } = "";
	
	[JsonPropertyName("fastestLap")]
	public bool IsFastestLap { get; set; }

	/*------------------------------------*/
	/* Join                               */
	/*------------------------------------*/
	[JsonPropertyName("driverId")]
	public int DriverId { get; set; }

	[JsonPropertyName("driver")]
	public Driver Driver { get; set; } = null!;

	[JsonPropertyName("raceId")]
	public int RaceId { get; set; }

	[JsonPropertyName("race")]
	public Race Race { get; set; } = null!;
}