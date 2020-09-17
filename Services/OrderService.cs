using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGreenAtom.DAL;
using TestGreenAtom.Models;
using TestGreenAtom.ViewModels;

namespace TestGreenAtom.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return (await _orderRepository.GetWithInclude(x => x.Products)).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetWithInclude(x=> x.Products);
        }

        public async Task DeleteOrder(Guid id)
        {
            var order = (await _orderRepository.GetWithInclude(x=>x.Products)).FirstOrDefault(x=>x.Id == id);

            for (var i = 0; i < order.Products?.Count; i++)
            {
                await _productRepository.Delete(order.Products[i].Id);
            }

            await _orderRepository.Delete(id);
        }

        public async Task AddOrder(OrderVM orderVM)
        {
            var productList = new List<Product>();

            orderVM.Products?.ForEach(x => productList.Add(new Product(x.Name, x.Price)));

            var order = new Order(orderVM.Description, productList);

            await _productRepository.Insert(productList);
            await _orderRepository.Insert(order);
        }

        public async Task ChangeOrder(OrderVM orderVM)
        {
            var order = await _orderRepository.GetById(orderVM.Id);

            var newProductList = await ConvertProductVMListToProductList(orderVM.Products);

            order.ChangeDescription(orderVM.Description);
            order.ChangeProductList(newProductList);

            await _orderRepository.Update(order);
        }
        private async Task<List<Product>> ConvertProductVMListToProductList(List<ProductVM> ProductVMList)
        {
            var productList = new List<Product>();
            var allProducts = await _productRepository.GetAll();

            foreach (var productVM in ProductVMList)
            {
                var isItNewProduct = productVM.Id == Guid.Empty;

                if (isItNewProduct)
                {
                    productList.Add(new Product(productVM.Name, productVM.Price));
                    continue;
                }

                var productToChange = allProducts.Find(x => x.Id == productVM.Id);

                productToChange.ChangeName(productVM.Name);

                productToChange.ChangePrice(productVM.Price);

                productList.Add(productToChange);
            }

            return productList;
        }
    }
}
