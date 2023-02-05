using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Order_have_Tree")]
    public partial class OrderHaveTree
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int TreeId { get; set; }
        public bool IsActives { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("OrderHaveTrees")]
        public virtual TreeOrder Order { get; set; } = null!;
        [ForeignKey("TreeId")]
        [InverseProperty("OrderHaveTrees")]
        public virtual Tree Tree { get; set; } = null!;
    }
}
