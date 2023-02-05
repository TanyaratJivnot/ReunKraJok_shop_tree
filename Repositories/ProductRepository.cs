using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.Data.SqlClient;

namespace API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext _databasecontext;
        public ProductRepository(DatabaseContext databaseContext)
        {
            _databasecontext = databaseContext;
        }

        public async Task<List<Tree>> GetAllTree()
        {
           Tree tree=null;
            using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
            {
                var treeAll = new List<Tree>();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GetAllTree";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        tree = new Tree()
                        {
                           TreeId = dataReader.GetInt32("TreeId"),
                            TreeName = dataReader.GetString("TreeName"),
                            Cost = dataReader.GetInt32("Cost"),
                            TreeImg = dataReader.GetString("TreeImg"),
                            Temperature = dataReader.GetString("Temperature"),
                            Soil = dataReader.GetString("Soil"),
                            Water = dataReader.GetString("Water"),
                            Sunlight = dataReader.GetString("Sunlight"),
                            IsActive  = dataReader.GetBoolean("IsActive")
                        };
                        treeAll.Add(tree);
                    }
                    await conn.CloseAsync();
                }
                return treeAll;
            }
        }

        public async Task<List<Tree>> GetDataTreeCatIndoor()
        {
            Tree tree=null;
            using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
            {
                var treeIndoor = new List<Tree>();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GetDataTreeCatIndoor";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        tree = new Tree()
                        {
                           TreeId = dataReader.GetInt32("TreeId"),
                            TreeName = dataReader.GetString("TreeName"),
                            Cost = dataReader.GetInt32("Cost"),
                            TreeImg = dataReader.GetString("TreeImg"),
                            Temperature = dataReader.GetString("Temperature"),
                            Soil = dataReader.GetString("Soil"),
                            Water = dataReader.GetString("Water"),
                            Sunlight = dataReader.GetString("Sunlight"),
                            IsActive  = dataReader.GetBoolean("IsActive")
                        };
                        treeIndoor.Add(tree);
                    }
                    await conn.CloseAsync();
                }
                return treeIndoor;
            }
        }

        public async Task<List<Tree>> GetDataTreeHaveCatOutdoor()
        {
           Tree tree=null;
            using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
            {
                var treeOutdoor = new List<Tree>();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GetDataTreeHaveCatOutdoor";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        tree = new Tree()
                        {
                           TreeId = dataReader.GetInt32("TreeId"),
                            TreeName = dataReader.GetString("TreeName"),
                            Cost = dataReader.GetInt32("Cost"),
                            TreeImg = dataReader.GetString("TreeImg"),
                            Temperature = dataReader.GetString("Temperature"),
                            Soil = dataReader.GetString("Soil"),
                            Water = dataReader.GetString("Water"),
                            Sunlight = dataReader.GetString("Sunlight"),
                            IsActive  = dataReader.GetBoolean("IsActive")
                        };
                        treeOutdoor.Add(tree);
                    }
                    await conn.CloseAsync();
                }
                return treeOutdoor;
            }
        }

        /* --------------productDetail----------------------------- */
        public async Task<List<Tree>> getProductAll(int TreeId)
        {
             Tree tree = null;
           using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
           {
            var treeDetail = new List<Tree>();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GetProductTODetail";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TreeId", SqlDbType.Int).Value = TreeId;
                    await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        tree = new Tree()
                        {
                            TreeId = dataReader.GetInt32("TreeId"),
                            TreeName = dataReader.GetString("TreeName"),
                            Cost = dataReader.GetInt32("Cost"),
                            TreeImg = dataReader.GetString("TreeImg"),
                            Temperature = dataReader.GetString("Temperature"),
                            Soil = dataReader.GetString("Soil"),
                            Water = dataReader.GetString("Water"),
                            Sunlight = dataReader.GetString("Sunlight"),
                            IsActive  = dataReader.GetBoolean("IsActive")
                        };
                        treeDetail.Add(tree);
                    }
                    await conn.CloseAsync();
            }
            return treeDetail;
           }
        }

        public async Task<List<TreeCategory>> GetProductCategories()
        {
            TreeCategory treeCategory=null;
            using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
            {
                var treecate = new List<TreeCategory>();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GetProductCategories";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        treeCategory = new TreeCategory()
                        {
                            CategoryId = dataReader.GetInt32("CategoryId"),
                            CategoryName= dataReader.GetString("CategoryName"),
                            IsActives = dataReader.GetBoolean("IsActives")
                        };
                        treecate.Add(treeCategory);
                    }
                    await conn.CloseAsync();
                }
                return treecate;
            }
        }

        public async Task<List<Tree>> GetProductsAll(string TypeName)
        {
           Tree treeAll = null;
           using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
           {
            var treetypeAll = new List<Tree>();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GetProductsAll";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@typName", SqlDbType.NVarChar).Value = TypeName;
                    await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        treeAll = new Tree()
                        {
                            TreeId = dataReader.GetInt32("TreeId"),
                            TreeName = dataReader.GetString("TreeName"),
                            Cost = dataReader.GetInt32("Cost"),
                            TreeImg = dataReader.GetString("TreeImg"),
                            Temperature = dataReader.GetString("Temperature"),
                            Soil = dataReader.GetString("Soil"),
                            Water = dataReader.GetString("Water"),
                            Sunlight = dataReader.GetString("Sunlight"),
                            IsActive  = dataReader.GetBoolean("IsActive")
                        };
                        treetypeAll.Add(treeAll);
                    }
                    await conn.CloseAsync();
            }
            return treetypeAll;
           }

        }

        public Task<List<Tree>> GetProductTODetail(int TreeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TreeType>> GetTreeTypeAll()
        {
             TreeType treeType =null;
            using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
            {
                var treetype = new List<TreeType>();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GetTreeTypeAll";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        treeType = new TreeType()
                        {
                            TypeId = dataReader.GetInt32("TypeId"),
                            TypeName = dataReader.GetString("TypeName"),
                            IsActives = dataReader.GetBoolean("IsActives")
                        };
                        treetype.Add(treeType);
                    }
                    await conn.CloseAsync();
                }
                return treetype;
            }
        }

        public async Task<List<Tree>> GetTreeTypeIndoor(string TypeName)
        {
           Tree treeIndoor = null;
           using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
           {
            var treetypeIndoor = new List<Tree>();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GetTreeTypeIndoor";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@typName", SqlDbType.NVarChar).Value = TypeName;
                   await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        treeIndoor = new Tree()
                        {
                            TreeId = dataReader.GetInt32("TreeId"),
                            TreeName = dataReader.GetString("TreeName"),
                            Cost = dataReader.GetInt32("Cost"),
                            TreeImg = dataReader.GetString("TreeImg"),
                            Temperature = dataReader.GetString("Temperature"),
                            Soil = dataReader.GetString("Soil"),
                            Water = dataReader.GetString("Water"),
                            Sunlight = dataReader.GetString("Sunlight"),
                            IsActive  = dataReader.GetBoolean("IsActive")
                        };
                        treetypeIndoor.Add(treeIndoor);
                    }
                    await conn.CloseAsync();
            }
            return treetypeIndoor;
           }
        }

        public async Task<List<Tree>> GetTreeTypeOutdoor(string TypeName)
        {
             Tree treeOutdoor = null;
           using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
           {
            var treetypeOutdoor = new List<Tree>();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GetTreeTypeOutdoor";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@typName", SqlDbType.NVarChar).Value = TypeName;
                    await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        treeOutdoor = new Tree()
                        {
                            TreeId = dataReader.GetInt32("TreeId"),
                            TreeName = dataReader.GetString("TreeName"),
                            Cost = dataReader.GetInt32("Cost"),
                            TreeImg = dataReader.GetString("TreeImg"),
                            Temperature = dataReader.GetString("Temperature"),
                            Soil = dataReader.GetString("Soil"),
                            Water = dataReader.GetString("Water"),
                            Sunlight = dataReader.GetString("Sunlight"),
                            IsActive  = dataReader.GetBoolean("IsActive")
                        };
                        treetypeOutdoor.Add(treeOutdoor);
                    }
                    await conn.CloseAsync();
            }
            return treetypeOutdoor;
           }
        }

        public async Task<List<Tree>> serchProductAll(string treeName)
        {
              Tree treeSreach = null;
           using (SqlConnection conn = new SqlConnection("Server=119.59.96.90;Initial Catalog=ReunKraJok_Db;User ID=ReunKraJok_backend;Password=cOpg3&704"))
           {
            var tree = new List<Tree>();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SearchTree";
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Treename", SqlDbType.NVarChar).Value = treeName;
                    await conn.OpenAsync();
                    SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        treeSreach = new Tree()
                        {
                            TreeId = dataReader.GetInt32("TreeId"),
                            TreeName = dataReader.GetString("TreeName"),
                            Cost = dataReader.GetInt32("Cost"),
                            TreeImg = dataReader.GetString("TreeImg"),
                            Temperature = dataReader.GetString("Temperature"),
                            Soil = dataReader.GetString("Soil"),
                            Water = dataReader.GetString("Water"),
                            Sunlight = dataReader.GetString("Sunlight"),
                            IsActive  = dataReader.GetBoolean("IsActive")
                        };
                        tree.Add(treeSreach);
                    }
                    await conn.CloseAsync();
            }
            return tree;
           }
        }
    }
}