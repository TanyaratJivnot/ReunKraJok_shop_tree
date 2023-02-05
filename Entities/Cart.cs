using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Cart")]
    public partial class Cart
    {
        public Cart()
        {
            OrderInCarts = new HashSet<OrderInCart>();
        }

        [Key]
        public int CartId { get; set; }

        [InverseProperty("Cart")]
        public virtual ICollection<OrderInCart> OrderInCarts { get; set; }
    }
}
