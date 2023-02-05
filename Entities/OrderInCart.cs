using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Order_in_Cart")]
    public partial class OrderInCart
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int CartId { get; set; }
        public bool IsActives { get; set; }

        [ForeignKey("CartId")]
        [InverseProperty("OrderInCarts")]
        public virtual Cart Cart { get; set; } = null!;
        [ForeignKey("OrderId")]
        [InverseProperty("OrderInCarts")]
        public virtual TreeOrder Order { get; set; } = null!;
    }
}
