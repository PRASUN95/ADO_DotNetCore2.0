using Common.Model;
using EmployeeDataManagement;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADOtutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeDbManager _employeeDbManager;

        public HomeController(IEmployeeDbManager employeeDbManager)
        {
            _employeeDbManager = employeeDbManager;
        }
        public async Task<IActionResult> Index()
        {
            var respone = await _employeeDbManager.getAllEmployee();
            ViewBag.employeeData = respone.Data;
            return View();
        }
        public async Task<ActionResult> GetEmployee(string Id)
        {
            return Json(await _employeeDbManager.GetEmployee(Id));
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<Respone> DeleteEmp(string Id)
        {
            var res = await _employeeDbManager.DeleteEmployee(Id);
            return res;
        }
    }
}
