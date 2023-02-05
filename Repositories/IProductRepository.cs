using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Repositories
{
    public interface IProductRepository
    {
        Task<List<TreeCategory>> GetProductCategories();
        Task<List<TreeType>> GetTreeTypeAll();/* test */
        /* All product */
         Task<List<Tree>> GetProductsAll(string TypeName);
         Task<List<Tree>> GetTreeTypeIndoor(string TypeName);
         Task<List<Tree>> GetTreeTypeOutdoor(string TypeName);
        Task<List<Tree>> GetAllTree();/* productAll */
        Task<List<Tree>> GetDataTreeCatIndoor();
        Task<List<Tree>> GetDataTreeHaveCatOutdoor();
        /* GetDatail */
          Task<List<Tree>> getProductAll(int TreeId);
          Task<List<Tree>> serchProductAll(string treeName);

    }
}