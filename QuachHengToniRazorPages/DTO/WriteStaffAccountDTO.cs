using System.ComponentModel.DataAnnotations;

namespace QuachHengToniRazorPages.DTO
{
    public record WriteStaffAccountDTO 
    {
        [StringLength(50, MinimumLength = 3)]
        public string StaffId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string FullName { get; set; }

        [EmailAddress]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3)]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }

        [Range(1, 2)]
        public int? Role { get; set; }
    }
}
