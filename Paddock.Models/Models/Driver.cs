using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Driver
{
	[Key]
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("number")]
	public int? Number { get; set; }

	[Required, StringLength(3, MinimumLength = 2)]
	[JsonPropertyName("code")]
	public string Code { get; set; } = "";

	[Required, StringLength(100, MinimumLength = 2)]
	[JsonPropertyName("firstname")]
	public string Firstname { get; set; } = "";

	[Required, StringLength(100, MinimumLength = 2)]
	[JsonPropertyName("lastname")]
	public string Lastname { get; set; } = "";

	[Required, DataType(DataType.Date)]
	[JsonPropertyName("dateOfBirth")]
	public DateTime DateOfBirth { get; set; }

	[Required, StringLength(100, MinimumLength = 3)]
	[JsonPropertyName("nationality")]
	public string Nationality { get; set; } = "";

	/*------------------------------------*/
	/* Join                               */
	/*------------------------------------*/
	[JsonPropertyName("constructorId")]
	public int ConstructorId { get; set; }

	[JsonPropertyName("constructor")]
	public Constructor Constructor { get; set; } = null!;
}