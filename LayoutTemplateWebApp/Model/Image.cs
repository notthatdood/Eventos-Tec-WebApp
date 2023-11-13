using System.ComponentModel.DataAnnotations;

public class Image
{
	[Key]
	public int idImage { get; set; }

	[Required]
	[MaxLength(255)]
	public string url { get; set; }

	[Required]
	[MaxLength(50)]
	public string alternative_text { get; set; }

	[Required]
	[MaxLength(250)]
	public string descriptive_text { get; set; }
}