using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Choose_TreeCat")]
    public partial class ChooseTreeCat
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int CategoryId { get; set; }
        public bool IsActives { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("ChooseTreeCats")]
        public virtual TreeCategory Category { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("ChooseTreeCats")]
        public virtual User User { get; set; } = null!;
    }
}
