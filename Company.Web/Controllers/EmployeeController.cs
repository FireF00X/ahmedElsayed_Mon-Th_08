using Company.Data.Entities;
using Company.Services.Interfaces;
using Company.Services.Interfaces.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public IActionResult Index(string searchInp)
        {
            IEnumerable<EmployeeDto> employees;
            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeService.GetAll();
            else
                employees = _employeeService.GetEmployeeByName(searchInp);
            return View(employees);
        }
        public IActionResult Create()
        {
            ViewData["DeptId"] = _departmentService.GetAll().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            _employeeService.Add(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            var emp = _employeeService.GetById(id.Value);
            return View(emp);
        }
        public IActionResult Update(int id)
        {
            return Details(id);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            //_employeeService.Update(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(_employeeService.GetById(id));
            return RedirectToAction("Index");
        }
    }
}
