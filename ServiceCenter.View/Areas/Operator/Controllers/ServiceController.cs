using Microsoft.AspNetCore.Mvc;

namespace ServiceCenter.View.Areas.Operator.Controllers
{
    [Area("Operator")]
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
