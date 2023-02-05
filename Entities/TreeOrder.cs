using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("TreeOrder")]
    public partial class TreeOrder
    {
        public TreeOrder()
        {
            Admins = new HashSet<Admin>();
            Comments = new HashSet<Comment>();
            OrderHaveTrees = new HashSet<OrderHaveTree>();
            OrderInCarts = new HashSet<OrderInCart>();
            Reviews = new HashSet<Review>();
            Users = new HashSet<User>();
        }

        [Key]
        public int OrderId { get; set; }
        [StringLength(50)]
        public string MoneyTransStatus { get; set; } = null!;
        [Unicode(false)]
        public string ImgSlip { get; set; } = null!;
        public bool IsActive { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<Admin> Admins { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderHaveTree> OrderHaveTrees { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderInCart> OrderInCarts { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<User> Users { get; set; }
    }
}
