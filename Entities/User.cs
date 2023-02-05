using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            ChooseTreeCats = new HashSet<ChooseTreeCat>();
            Comments = new HashSet<Comment>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        public int UserId { get; set; }
        public int? OrderId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; } = null!;
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [StringLength(10)]
        public string Password { get; set; } = null!;
        [StringLength(500)]
        public string Address { get; set; } = null!;
        [StringLength(50)]
        public string Province { get; set; } = null!;
        [StringLength(50)]
        public string PostalCode { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string Tel { get; set; } = null!;
        [Unicode(false)]
        public string UserImg { get; set; } = null!;
        public bool IsActive { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("Users")]
        public virtual TreeOrder? Order { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ChooseTreeCat> ChooseTreeCats { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
