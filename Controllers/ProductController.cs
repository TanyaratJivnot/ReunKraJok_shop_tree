using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService =productService;
        }

        [HttpGet("GetProductCategories")]
        public async Task<IActionResult> GetProductCategories()
        {
            var response = await _productService.GetProductCategories();
            return Ok(response);
        }
        [HttpGet("GetTreeTypeAll")]
        public async Task<IActionResult> GetTreeTypeAll()
        {
            var response = await _productService.GetTreeTypeAll();
            return Ok(response);
        }
        [HttpGet("GetProductsAll")]
        public async Task<IActionResult> GetProductsAll(string TypeName)
        {
            var response = await _productService.GetProductsAll(TypeName);
            return Ok(response);
        }
         [HttpGet("GetTreeTypeIndoo")]
        public async Task<IActionResult> GetTreeTypeIndoor(string TypeName)
        {
            var response = await _productService.GetTreeTypeIndoor(TypeName);
            return Ok(response);
        }
         [HttpGet("GetTreeTypeOutdoor")]
        public async Task<IActionResult> GetTreeTypeOutdoor(string TypeName)
        {
            var response = await _productService.GetTreeTypeOutdoor(TypeName);
            return Ok(response);
        }
         [HttpGet("GetAllTree")]
        public async Task<IActionResult> GetAllTree()
        {
            var response = await _productService.GetAllTree();
            return Ok(response);
        }
         [HttpGet("GetDataTreeCatIndoor")]
        public async Task<IActionResult> GetDataTreeCatIndoor()
        {
            var response = await _productService.GetDataTreeCatIndoor();
            return Ok(response);
        }
         [HttpGet("GetDataTreeHaveCatOutdoor")]
        public async Task<IActionResult> GetDataTreeHaveCatOutdoor()
        {
            var response = await _productService.GetDataTreeHaveCatOutdoor();
            return Ok(response);
        }
         [HttpGet("GetProductTODetail/{TreeId}")]
        public async Task<IActionResult> getProductAll(int TreeId)
        {
            var response = await _productService.getProductAll(TreeId);
            return Ok(response);
        }
        [HttpGet("serchProductAll")]
        public async Task<IActionResult> serchProductAll(string treeName)
        {
            var response = await _productService.serchProductAll(treeName);
            return Ok(response);
        }

        /* ทำการเพิ่มต้นไม้ ในส่วนของหน้า อัพเดทโปรดัก */
        [HttpPost("CreatProductAdmin")]
        /* @TreeId,@AdminId,@TreeName,@Cost,@TreeImg,@Temperature,@Soil,@Water,@Sunlight,@IsActive */
            public async Task<IActionResult> CreatProductAdmin(int TreeId,int admin,string Tname, int Cost, string Timg,string temp,string soil,string water,string sun,Boolean IsActive)
            {
                using (SqlConnection connection = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "InsertCreateTree";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TreeId", SqlDbType.Int).Value = TreeId;
                        cmd.Parameters.Add("@AdminId", SqlDbType.Int).Value = admin;
                        cmd.Parameters.Add("@TreeName", SqlDbType.NVarChar).Value = Tname;
                        cmd.Parameters.Add("@Cost", SqlDbType.Int).Value = Cost;
                        cmd.Parameters.Add("@TreeImg", SqlDbType.NVarChar).Value = Timg;
                        cmd.Parameters.Add("@Temperature", SqlDbType.NVarChar).Value = temp;
                        cmd.Parameters.Add("@Water", SqlDbType.NVarChar).Value = water;
                        cmd.Parameters.Add("@Sunlight", SqlDbType.Char).Value = sun;
                        cmd.Parameters.Add("@Soil", SqlDbType.NVarChar).Value = soil;
                        cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                       
                        await connection.OpenAsync();
                        SqlDataReader reader = cmd.ExecuteReader();
                        await connection.CloseAsync();
                        return Ok();
                    }
                }
            }
             /* ทำแก้ไขรายละเอียดของต้นไม้ ในส่วนของหน้า อีดิทโปรดัก */
            [HttpPut("UpdateEditProduct")]
            public async Task<IActionResult> UpdateEditProduct(int treeId,int admin,string treeName, int Cost,string imgT,int typT,int category)
            {
                using (SqlConnection connection = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UpdateEditProduct";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = treeId;
                        cmd.Parameters.Add("@admin", SqlDbType.Int).Value = admin;
                        cmd.Parameters.Add("@product", SqlDbType.NVarChar).Value = treeName;
                        cmd.Parameters.Add("@cost", SqlDbType.Int).Value = Cost;
                        cmd.Parameters.Add("@type", SqlDbType.Int).Value = typT;
                        cmd.Parameters.Add("@category", SqlDbType.Int).Value = category;
                        cmd.Parameters.Add("@img", SqlDbType.NVarChar).Value = imgT;
                       
                        await connection.OpenAsync();
                        SqlDataReader reader = cmd.ExecuteReader();
                        await connection.CloseAsync();
                        return Ok();
                    }
                }
            }
             /* ทำลบต้นไม้ ในส่วนของหน้า ลบโปรดัก */
        [HttpDelete("deleteProduct")]
        public async Task<IActionResult> DeleteProduct(int treeId)
        {
            using (SqlConnection connection = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DelProducts";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TreeId", SqlDbType.Int).Value = treeId;
                    await connection.OpenAsync();
                    SqlDataReader reader = cmd.ExecuteReader();
                    await connection.CloseAsync();
                    return Ok();
                }
            }
        }
    }
}