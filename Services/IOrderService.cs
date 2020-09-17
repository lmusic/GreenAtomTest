using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestGreenAtom.Models;
using TestGreenAtom.ViewModels;

namespace TestGreenAtom.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrder(Guid id);

        Task<List<Order>> GetOrders();

        Task DeleteOrder(Guid id);

        Task AddOrder(OrderVM orderVM);

        Task ChangeOrder(OrderVM orderVM);

    }
}
