using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceCenter.Domain.Viewmodel.Abonent;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Operator.Controllers
{
    [Area("Operator")]
    public class AbonentController : Controller
    {
        private readonly IAbonentService _abonentService;
        private readonly ITariffService _tariffService;

        public AbonentController(IAbonentService abonentService, ITariffService tariffService)
        {
            _abonentService = abonentService;
            _tariffService = tariffService;
        }

        [HttpGet]
        public IActionResult Abonents()
        {
            var response = _abonentService.GetAbonentView();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult AbonentAdd()
        {
            var response = _tariffService.Get();
            ViewBag.Tariff = new SelectList(response.Result, "Tariff_ID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AbonentAdd(AbonentViewModel model)
        {
            var response = await _abonentService.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Abonents", "Abonent");
            }
            return View("Error", $"{response.Description}");
        }
    }
}
