using System;
using System.ComponentModel.DataAnnotations;

namespace QuachHengToniRazorPages.DTO
{
	public record CustomerRegisterDTO
	{
		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string CustomerName { get; set; }

		[Required]
		[Phone]
		[StringLength(50, MinimumLength = 3)]
		public string Mobile { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(50, MinimumLength = 3)]
		public string CustomerEmail { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		[DataType(DataType.Password)]
		public string CustomerPassword { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		[DataType(DataType.Password)]
		[Compare("CustomerPassword")]
		public string ConfirmCustomerPassword { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string IdentityCard { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string LicenceNumber { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime? LicenceDate { get; set; }
	}
}
