using System;
using System.ComponentModel.DataAnnotations;

namespace QuachHengToniRazorPages.DTO
{
    public record CreateCarDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string CarId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string CarName { get; set; }

        [Required]
        [Range(1886, 2023)]
        public int? CarModelYear { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Color { get; set; }

        [Required]
        [Range(1, 100)]
        public int? Capacity { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? ImportDate { get; set; }

        [Required]
        [Range(1d, 1000d)]
        public decimal? RentPrice { get; set; }

        [Required]
        [Range(0, 1)]
        public int? Status { get; set; }

        [Required]
        public string ProducerId { get; set; }
    }
}
