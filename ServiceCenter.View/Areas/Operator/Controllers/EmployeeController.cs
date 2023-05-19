﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceCenter.Domain.Viewmodel.Employee;
using ServiceCenter.Service.Interfaces;

namespace ServiceCenter.View.Areas.Operator.Controllers
{
    [Area("Operator")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;

        public EmployeeController(IEmployeeService employeeService, IUserService userService)
        {
            _employeeService = employeeService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Employeers()
        {
            var response = _employeeService.GetEmployeeView();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Result);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            var response = _userService.Get();
            ViewBag.Users = new SelectList(response.Result, "User_ID", "Username");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeViewModel model)
        {
            var response = await _employeeService.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Employeers", "Employee");
            }
            return View("Error", $"{response.Description}");
        }
    }
}
