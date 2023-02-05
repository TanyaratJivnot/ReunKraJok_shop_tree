using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Review")]
    public partial class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? RateReview { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("Reviews")]
        public virtual TreeOrder Order { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Reviews")]
        public virtual User User { get; set; } = null!;
    }
}
