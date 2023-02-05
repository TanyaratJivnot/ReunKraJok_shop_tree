using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _databasecontext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databasecontext = databaseContext;
        }

        public Comment commentProduct(Comment comment)
        {
            _databasecontext.Comments.Add(comment);
            _databasecontext.SaveChanges();
            return comment;
        }

        public async Task<User?> LoginUser(string email, string password)
        {
            User user=null;
            
             using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "LoginUser";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value =email;
                    cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar).Value =password;

                    await conn.OpenAsync();
                     SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                     while (dataReader.Read())
                     {
                         user = new User()
                         {
                            UserId = dataReader.GetInt32("UserId"),
                             UserName = dataReader.GetString("UserName"),
                             Email = dataReader.GetString("Email"),
                             Password = dataReader.GetString("Password"),
                             Address = dataReader.GetString("Address"),
                             PostalCode = dataReader.GetString("PostalCode"),
                             Province = dataReader.GetString("Province"),
                             Tel = dataReader.GetString("Tel"),
                             UserImg = dataReader.GetString("UserImg"),
                             IsActive  = dataReader.GetBoolean("IsActive")
                         };
                        
                     }
                     await conn.CloseAsync();
                }
              
            }
            if(user!=null){
                return user;
            }
              return null;
        }
        public async Task<Admin?> LoginAdmin(string email, string password)
        {
            Admin admin= null;
            using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
            {
                  using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "GetAdmin";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AdminEmail", System.Data.SqlDbType.NVarChar).Value =email;
                    cmd.Parameters.Add("@AdminPassword", System.Data.SqlDbType.NVarChar).Value =password;

                    await conn.OpenAsync();
                     SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                     while (dataReader.Read())
                     {
                         admin = new Admin()
                         {
                            AdminId = dataReader.GetInt32("AdminId"),
                            AdminName = dataReader.GetString("AdminName"),
                            AdminImg = dataReader.GetString("AdminImg"),
                            IsActive = dataReader.GetBoolean("IsActive")
                           
                         };
                        
                     }
                     await conn.CloseAsync();
                }
                if(admin!=null){
                return admin;
            }
              return null;
            }
        }

        public User RegisterUser(User user)
        {
            _databasecontext.Users.Add(user);
            _databasecontext.SaveChanges();
            return user;
        }

    }   
}
  
