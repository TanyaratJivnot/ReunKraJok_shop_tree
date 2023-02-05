using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("TreeType")]
    public partial class TreeType
    {
        public TreeType()
        {
            TreeCatHaveTypes = new HashSet<TreeCatHaveType>();
            TreeHaveTreeTypes = new HashSet<TreeHaveTreeType>();
        }

        [Key]
        public int TypeId { get; set; }
        [StringLength(100)]
        public string TypeName { get; set; } = null!;
        public bool IsActives { get; set; }

        [InverseProperty("Type")]
        public virtual ICollection<TreeCatHaveType> TreeCatHaveTypes { get; set; }
        [InverseProperty("Type")]
        public virtual ICollection<TreeHaveTreeType> TreeHaveTreeTypes { get; set; }
    }
}
