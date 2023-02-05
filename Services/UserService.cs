using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories;

namespace API.Services
{
    public class UserService:IUserService
    {
         private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository){
            _userRepository=userRepository;
        }

        public Comment commentProduct(Comment comment)
        {
            return _userRepository.commentProduct(comment);
        }

        public Task<Admin?> LoginAdmin(string email, string password)
        {
            return _userRepository.LoginAdmin(email,password);
        }

        public Task<User?> LoginUser(string email, string password)
        {
            return _userRepository.LoginUser(email,password);
        }

        public User RegisterUser(User user)
        {
            return _userRepository.RegisterUser(user);
        }

    
    }
}