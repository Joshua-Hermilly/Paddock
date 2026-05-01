using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Season
{
	[Key]
	[JsonPropertyName("year")]
	public int Year { get; set; }

	/*------------------------------------*/
	/* Join                               */
	/*------------------------------------*/
	[JsonPropertyName("races")]
	public ICollection<Race> Races { get; set; } = [];
}