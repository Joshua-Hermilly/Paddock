using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ConstructorDto
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	[JsonPropertyName("nationality")]
	public string Nationality { get; set; } = "";
}