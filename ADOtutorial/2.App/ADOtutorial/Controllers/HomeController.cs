using EmployeeDataManagement;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ADOtutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeDbManager _employeeDbManager;

        public HomeController(IEmployeeDbManager employeeDbManager)
        {
            _employeeDbManager = employeeDbManager;
        }
        public JsonResult Index()
        {
            return Json(_employeeDbManager.getAllEmployee());
        }

        public ActionResult GetEmployee(string Id)
        {
            return Json(_employeeDbManager.GetEmployee(Id));
        }
    }
}
