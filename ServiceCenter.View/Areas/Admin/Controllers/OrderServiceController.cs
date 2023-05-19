using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Domain.Viewmodel.Abonent;
using ServiceCenter.Domain.Viewmodel.OrderService;
using ServiceCenter.Service.Implementations;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public OrderServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult Services() 
        {
            var response = _serviceService.GetServiceView();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult CreateService() => View();

        [HttpPost]
        public async Task<IActionResult> CreateService(OrderServiceViewModel model)
        {
            var response = await _serviceService.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Services", "OrderService");
            }
            return View("Error", $"{response.Description}");
        }
    }
}
