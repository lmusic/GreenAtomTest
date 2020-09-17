using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestGreenAtom.DAL;
using TestGreenAtom.Models;
using TestGreenAtom.ViewModels;

namespace TestGreenAtom.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _productRepository.GetAll();

            return products;
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task AddProduct(ProductVM productVM)
        {
            var product = new Product(productVM.Name, productVM.Price);

            await _productRepository.Insert(product);
        }

        public async Task ChangeProduct(ProductVM productVM)
        {
            var product = await _productRepository.GetById(productVM.Id);

            product.ChangeName(productVM.Name);
            product.ChangePrice(productVM.Price);

            await _productRepository.Update(product);
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productRepository.Delete(id);
        }


    }
}
