using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceCenter.Domain.Viewmodel.Abonent;
using ServiceCenter.Service.Implementations;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        [HttpGet]
        public IActionResult UpdateAbonent(AbonentViewModel model)
        {
            var response = _tariffService.Get();
            ViewBag.Tariff = new SelectList(response.Result, "Tariff_ID", "Name");
            var response2 = _abonentService.GetById(model.Abonent_ID);
            return View(response2.Result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAbonent(uint Abonent_ID)
        {
            var response = await _abonentService.Remove(Abonent_ID);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Abonents", "Abonent");
            }
            return View("Error", $"{response.Description}");
        }
    }
}
