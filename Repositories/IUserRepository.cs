using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Repositories
{
    public interface IUserRepository
    {
        User RegisterUser(User user);
        Task<User?> LoginUser(string email,string password);
        Task<Admin?> LoginAdmin(string email,string password);
        Comment commentProduct(Comment comment);
    }
}