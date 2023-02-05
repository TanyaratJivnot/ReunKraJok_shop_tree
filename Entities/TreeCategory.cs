using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    [Table("TreeCategory")]
    public partial class TreeCategory
    {
        public TreeCategory()
        {
            ChooseTreeCats = new HashSet<ChooseTreeCat>();
            TreeCatHaveTypes = new HashSet<TreeCatHaveType>();
        }

        [Key]
        public int CategoryId { get; set; }
        [StringLength(30)]
        public string CategoryName { get; set; } = null!;
        public bool IsActives { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<ChooseTreeCat> ChooseTreeCats { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<TreeCatHaveType> TreeCatHaveTypes { get; set; }
    }
}
