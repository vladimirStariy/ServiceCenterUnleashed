using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Domain.Viewmodel.Abonent;
using ServiceCenter.Domain.Viewmodel.Material;
using ServiceCenter.Service.Implementations;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public IActionResult Materials()
        {
            var response = _materialService.GetMaterialView();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult CreateMaterial() => View();

        [HttpPost]
        public async Task<IActionResult> CreateMaterial(MaterialViewModel model)
        {
            var response = await _materialService.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Materials", "Material");
            }
            return View("Error", $"{response.Description}");
        }
    }
}
