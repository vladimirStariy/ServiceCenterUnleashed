using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceCenter.Domain.Viewmodel.Tariff;
using ServiceCenter.Domain.Viewmodel.TariffType;
using ServiceCenter.Service.Implementations;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TariffController : Controller
    {
        private readonly ITariffTypeService _tariffTypeService;
        private readonly ITariffService _tariffService;

        public TariffController(ITariffTypeService tariffTypeService, ITariffService tariffService)
        {
            _tariffTypeService = tariffTypeService;
            _tariffService = tariffService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TariffTypes()
        {
            var response = _tariffTypeService.GetTarifTypeView();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult Tariffs()
        {
            var response = _tariffService.GetTariffView();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult CreateTariffType() => View();

        [HttpPost]
        public async Task<IActionResult> CreateTariffType(TariffTypeViewModel model)
        {
            var response = await _tariffTypeService.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("TariffTypes", "Tariff");
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult CreateTariff()
        {
            var response = _tariffTypeService.Get();
            ViewBag.TariffTypesCmb = new SelectList(response.Result, "TariffType_ID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTariff(TariffViewModel model)
        {
            var response = await _tariffService.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Tariffs", "Tariff");
            }
            return View("Error", $"{response.Description}");
        }
    }
}
