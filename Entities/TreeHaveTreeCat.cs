using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("Tree_have_TreeCat")]
    public partial class TreeHaveTreeCat
    {
        [Key]
        public int TreeId { get; set; }
        [Key]
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
