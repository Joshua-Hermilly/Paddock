using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Location
{
	[Key]
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[Required, StringLength(100, MinimumLength = 2)]
	[JsonPropertyName("locality")]
	public string Locality { get; set; } = "";

	[Required, StringLength(100, MinimumLength = 2)]
	[JsonPropertyName("country")]
	public string Country { get; set; } = "";

	[JsonPropertyName("latitude")]
	public double Latitude { get; set; }

	[JsonPropertyName("longitude")]
	public double Longitude { get; set; }
}