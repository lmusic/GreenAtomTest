using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestGreenAtom.Models;
using TestGreenAtom.ViewModels;

namespace TestGreenAtom.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();

        public Task<Product> GetProduct(Guid id);

        public Task AddProduct(ProductVM productVM);

        public Task ChangeProduct(ProductVM productVM);

        public Task DeleteProduct(Guid id);

    }
}
