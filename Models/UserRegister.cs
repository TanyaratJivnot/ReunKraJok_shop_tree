using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class UserRegister
    {
        public class UserReques
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Address { get; set; }
            public string Province { get; set; }
            public string PostalCode { get; set; }
            public string Tel { get; set; }
            public string UserImg { get; set; }
            public bool IsActive { get; set; }
        }

    }
}