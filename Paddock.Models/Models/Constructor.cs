using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Constructor
{
	[Key]
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[Required, StringLength(100, MinimumLength = 3)]
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	[Required, StringLength(100, MinimumLength = 3)]
	[JsonPropertyName("nationality")]
	public string Nationality { get; set; } = "";

	/*------------------------------------*/
	/* Join                               */
	/*------------------------------------*/
	[JsonPropertyName("locationId")]
	public int ?LocationId { get; set; }

	[JsonPropertyName("location")]
	public Location ?Location { get; set; } = null!;
}