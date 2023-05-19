using Microsoft.AspNetCore.Mvc;

namespace ServiceCenter.View.Areas.Operator.Controllers
{
    [Area("Operator")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
