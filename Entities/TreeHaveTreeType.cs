using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Tree_have_TreeType")]
    public partial class TreeHaveTreeType
    {
        [Key]
        public int TreeId { get; set; }
        [Key]
        public int TypeId { get; set; }
        public bool IsActives { get; set; }

        [ForeignKey("TreeId")]
        [InverseProperty("TreeHaveTreeTypes")]
        public virtual Tree Tree { get; set; } = null!;
        [ForeignKey("TypeId")]
        [InverseProperty("TreeHaveTreeTypes")]
        public virtual TreeType Type { get; set; } = null!;
    }
}
