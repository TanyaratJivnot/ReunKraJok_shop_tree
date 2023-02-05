using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int? OrderId { get; set; }
        [Column("detail_comment")]
        [StringLength(500)]
        public string? DetailComment { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("Comments")]
        public virtual TreeOrder? Order { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Comments")]
        public virtual User User { get; set; } = null!;
    }
}
