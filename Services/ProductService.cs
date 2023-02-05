using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepositoryt){
            _productRepository = productRepositoryt;
        }

        public Task<List<Tree>> GetAllTree()
        {
            return _productRepository.GetAllTree();
        }

        public Task<List<Tree>> GetDataTreeCatIndoor()
        {
            return _productRepository.GetDataTreeCatIndoor();
        }

        public Task<List<Tree>> GetDataTreeHaveCatOutdoor()
        {
            return _productRepository.GetDataTreeHaveCatOutdoor();
        }

        public Task<List<Tree>> getProductAll(int TreeId)
        {
           return _productRepository.getProductAll(TreeId);
        }

        public Task<List<TreeCategory>> GetProductCategories()
        {
            return _productRepository.GetProductCategories();
        }

        public Task<List<Tree>> GetProductsAll(string TypeName)
        {
           return _productRepository.GetProductsAll(TypeName);
        }

        public Task<List<TreeType>> GetTreeTypeAll()
        {
            return _productRepository.GetTreeTypeAll();
        }

        public Task<List<Tree>> GetTreeTypeIndoor(string TypeName)
        {
            return _productRepository.GetTreeTypeIndoor(TypeName);
        }

        public Task<List<Tree>> GetTreeTypeOutdoor(string TypeName)
        {
            return _productRepository.GetTreeTypeOutdoor(TypeName);
        }

        public Task<List<Tree>> serchProductAll(string treeName)
        {
            return _productRepository.serchProductAll(treeName);
        }
    }
}