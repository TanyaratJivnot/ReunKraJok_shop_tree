using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CommentModel
    {
        public int UserId { get; set; }
        public string detail_comment { get; set; }
        public bool IsActive { get; set; }
    }
}