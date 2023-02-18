using System;
using System.ComponentModel.DataAnnotations;

namespace QuachHengToniRazorPages.DTO
{
    public class WriteCarDTO
    {
        [StringLength(50, MinimumLength = 3)]
        public string CarId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string CarName { get; set; }

        [Range(1886,  2023)]
        public int? CarModelYear { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Color { get; set; }

        [Range(1, 100)]
        public int? Capacity { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ImportDate { get; set; }

        [Range(1d, 1000d)]
        public decimal? RentPrice { get; set; }

        [Range(0, 1)]
        public int? Status { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string ProducerId { get; set; }
    }
}
