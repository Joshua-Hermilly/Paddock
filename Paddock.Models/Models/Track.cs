using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Track
{
	[Key]
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[Required, StringLength(100, MinimumLength = 3)]
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	/*------------------------------------*/
	/* Join                               */
	/*------------------------------------*/
	[JsonPropertyName("locationId")]
	public int LocationId { get; set; }

	[JsonPropertyName("location")]
	public Location Location { get; set; } = null!;
}