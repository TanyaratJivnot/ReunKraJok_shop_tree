using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static API.Models.UserRegister;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(DatabaseContext context,IUserService userService)
        {
           _userService=userService;
        }
        [HttpPost("RegisterUser")]/* เอาข้อมูลเข้า DB register */
        public IActionResult RegisterUser(UserReques user)
        {
            User _user = new User();
            _user.UserName = user.UserName;
            _user.Email = user.Email;
            _user.Password = user.Password;
            _user.Address = user.Address;
            _user.Province = user.Province;
            _user.PostalCode = user.PostalCode;
            _user.Tel = user.Tel;
            _user.UserImg = user.UserImg;
            _user.IsActive = user.IsActive;

            var response = _userService.RegisterUser(_user);
            return Ok(response);
        }
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel loginModel)
        {
              if (loginModel == null) return NotFound();
              var response = await _userService.LoginUser(loginModel.Email,loginModel.Password);
              var admin = await _userService.LoginAdmin(loginModel.Email,loginModel.Password);
              if(response==null){
                return Ok(admin);
              }
             return Ok(response);
        }
        [HttpPost("commentProduct")]
        public IActionResult commentProduct(CommentModel commentModel){
            Comment _comment = new Comment();
            _comment.UserId = commentModel.UserId;
            _comment.DetailComment = commentModel.detail_comment;
            _comment.IsActive = commentModel.IsActive;
             var response = _userService.commentProduct(_comment);
             return Ok(response);

        }
        /* หน้าสมัคร สมาชิก */
        [HttpPost("Register")]
            public async Task<IActionResult> PostBookingRoom(string name, string mail, string pass,string address,string province,string zip,string tel,string img,Boolean IsActive)
            {
                using (SqlConnection connection = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "RegisterUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = name;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mail;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pass;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;
                        cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = zip;
                        cmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = province;
                        cmd.Parameters.Add("@Tel", SqlDbType.Char).Value = tel;
                        cmd.Parameters.Add("@UserImg", SqlDbType.NVarChar).Value = img;
                        cmd.Parameters.Add("@Isactive", SqlDbType.NVarChar).Value = IsActive;
                        await connection.OpenAsync();
                        SqlDataReader reader = cmd.ExecuteReader();
                        await connection.CloseAsync();
                        return Ok();
                    }
                }
            }
             /* หน้าสมัคร แก้ไขที่อยุ่ของผู้ใช้ */
            [HttpPut("UpdateAdressUser")]
            public async Task<IActionResult> UpdateAdressUser(string adrress,int UserId, string province,string postalcode)
            {
                using (SqlConnection connection = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UpdateUsers";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = adrress;
                        cmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = province;
                        cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = postalcode;
                        await connection.OpenAsync();
                        SqlDataReader reader = cmd.ExecuteReader();
                        await connection.CloseAsync();
                        return Ok();
                    }
                }
            }
             /* หน้าสมัคร ลบออร์เดอร์สินค้าในตระก้าสินค้า */
        [HttpDelete("deleteOrderUser")]
        public async Task<IActionResult> DeleteProduct(int OrderId)
        {
            using (SqlConnection connection = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DelOrder";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = OrderId;
                    await connection.OpenAsync();
                    SqlDataReader reader = cmd.ExecuteReader();
                    await connection.CloseAsync();
                    return Ok();
                }
            }
        }   
    }
}