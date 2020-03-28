using EmployeeDataManagement;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ADOtutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeDbManager employeeDbManager;

        public HomeController()
        {
            employeeDbManager = new EmployeeDataManager(Startup.ConnectionString);
        }
        public JsonResult Index()
        {
            return Json(employeeDbManager.getAllEmployee());
        }

        public ActionResult GetEmployee(string Id)
        {
            EmployeeDataManager employeeDataManager = new EmployeeDataManager(Startup.ConnectionString);
            return Json(employeeDataManager.GetEmployee(Id));
        }
    }
}
