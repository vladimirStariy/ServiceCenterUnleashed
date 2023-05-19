using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Operator.Controllers
{
    [Area("Operator")]
    public class TariffController : Controller
    {
        private readonly ITariffTypeService _tariffTypeService;
        private readonly ITariffService _tariffService;

        public TariffController(ITariffTypeService tariffTypeService, ITariffService tariffService)
        {
            _tariffTypeService = tariffTypeService;
            _tariffService = tariffService;
        }
    }
}
