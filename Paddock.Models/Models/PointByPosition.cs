using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class PointByPosition
{
	[Key]
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("place")]
	public int Place { get; set; }

	[JsonPropertyName("points")]
	public double Points { get; set; }

	[JsonPropertyName("seasonYear")]
	public int SeasonYear { get; set; }

	[JsonPropertyName("season")]
	public Season Season { get; set; } = null!;
}