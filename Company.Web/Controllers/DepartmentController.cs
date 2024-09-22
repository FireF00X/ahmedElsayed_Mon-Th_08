using Company.Data.Entities;
using Company.Services.Interfaces;
using Company.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var allDepartments = _departmentService.GetAll();
            return View(allDepartments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            //_departmentService.Add(department);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            var dept = _departmentService.GetById(id.Value);
            return View(dept);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return Details(id);
        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            //_departmentService.Update(department);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var deletedDept = _departmentService.GetById(id);
            _departmentService.Delete(deletedDept);
            return RedirectToAction("Index");
        }
    }
}
