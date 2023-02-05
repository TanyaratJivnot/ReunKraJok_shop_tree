using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Admin")]
    public partial class Admin
    {
        public Admin()
        {
            Trees = new HashSet<Tree>();
        }

        [Key]
        public int AdminId { get; set; }
        public int? OrderId { get; set; }
        [StringLength(50)]
        public string AdminName { get; set; } = null!;
        [StringLength(50)]
        public string AdminEmail { get; set; } = null!;
        [StringLength(50)]
        public string AdminPassword { get; set; } = null!;
        [Unicode(false)]
        public string AdminImg { get; set; } = null!;
        public bool IsActive { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("Admins")]
        public virtual TreeOrder? Order { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<Tree> Trees { get; set; }
    }
}
