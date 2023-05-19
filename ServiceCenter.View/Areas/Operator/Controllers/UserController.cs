using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Operator.Controllers
{
    [Area("Operator")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
