using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Tree")]
    public partial class Tree
    {
        public Tree()
        {
            OrderHaveTrees = new HashSet<OrderHaveTree>();
            TreeHaveTreeTypes = new HashSet<TreeHaveTreeType>();
        }

        [Key]
        public int TreeId { get; set; }
        public int AdminId { get; set; }
        [StringLength(100)]
        public string TreeName { get; set; } = null!;
        public int Cost { get; set; }
        [StringLength(500)]
        public string TreeImg { get; set; } = null!;
        [StringLength(500)]
        public string Temperature { get; set; } = null!;
        [StringLength(500)]
        public string Soil { get; set; } = null!;
        [StringLength(500)]
        public string Water { get; set; } = null!;
        [StringLength(500)]
        public string Sunlight { get; set; } = null!;
        public bool IsActive { get; set; }

        [ForeignKey("AdminId")]
        [InverseProperty("Trees")]
        public virtual Admin Admin { get; set; } = null!;
        [InverseProperty("Tree")]
        public virtual ICollection<OrderHaveTree> OrderHaveTrees { get; set; }
        [InverseProperty("Tree")]
        public virtual ICollection<TreeHaveTreeType> TreeHaveTreeTypes { get; set; }
    }
}
