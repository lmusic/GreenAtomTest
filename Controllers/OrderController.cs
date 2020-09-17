using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestGreenAtom.Services;
using TestGreenAtom.ViewModels;

namespace TestGreenAtom.Controllers
{
    [Route("api/v1/orders/")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();

            return new JsonResult(orders);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrder(id);

            return new JsonResult(order);
        }
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderVM orderVM)
        {
            await _orderService.AddOrder(orderVM);

            return new JsonResult("order was added");
        }
        [Route("change")]
        [HttpPut]
        public async Task<IActionResult> ChangeOrder(OrderVM orderVM)
        {
            await _orderService.ChangeOrder(orderVM);

            return new JsonResult("order was changed");
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteOrder(id);

            return new JsonResult("order 1 is here");
        }
    }
}
