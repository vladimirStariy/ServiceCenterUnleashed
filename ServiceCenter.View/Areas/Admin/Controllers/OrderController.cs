using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Domain.Viewmodel.Employee;
using ServiceCenter.Domain.Viewmodel.Order;
using ServiceCenter.Service.Implementations;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Orders()
        {
            var response = _orderService.GetOrderView();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult CreateOrder() => View();

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel model)
        {
            var response = await _orderService.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Orders", "Order");
            }
            return View("Error", $"{response.Description}");
        }
    }
}
