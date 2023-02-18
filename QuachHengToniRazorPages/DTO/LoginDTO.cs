using BusinessObject;
using System.ComponentModel.DataAnnotations;

namespace QuachHengToniRazorPages.DTO
{
	public record LoginDTO
	{
		[Required]
		[StringLength(50, MinimumLength = 3)]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string Password { get; set; }
	}
}
