using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Services
{
    public interface IUserService
    {
        /* Task<User> RegisterUser(User user); */
        User RegisterUser(User user);
        Task<User?> LoginUser(string email,string password);
         Comment commentProduct(Comment comment);
         Task<Admin?> LoginAdmin(string email,string password);
    }
}