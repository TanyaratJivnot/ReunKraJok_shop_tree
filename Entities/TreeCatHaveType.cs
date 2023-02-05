using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("TreeCat_Have_Type")]
    public partial class TreeCatHaveType
    {
        [Key]
        public int CategoryId { get; set; }
        [Key]
        public int TypeId { get; set; }
        public bool IsActives { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TreeCatHaveTypes")]
        public virtual TreeCategory Category { get; set; } = null!;
        [ForeignKey("TypeId")]
        [InverseProperty("TreeCatHaveTypes")]
        public virtual TreeType Type { get; set; } = null!;
    }
}
