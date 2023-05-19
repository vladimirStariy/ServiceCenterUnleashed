using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Payments()
        {
            var response = _paymentService.GetPaymentView();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult CreatePayment() => View();
    }
}
