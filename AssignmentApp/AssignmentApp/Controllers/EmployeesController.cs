using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AA.Entities;
using AA.BAL;

namespace AssignmentApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;
        public EmployeesController(IEmployeeManager employeeManager, IDepartmentManager departmentManager)
        {
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
        }


        // GET: Employees
        public IActionResult Index()
        {
            var employees = _employeeManager.GetEmployees();
            return View(employees);
        }

        // GET: Employees/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var department = _employeeManager.GetEmployee(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            var departments = _departmentManager.GetDepartments();
            var managers = _employeeManager.GetManagers();
            ViewData["DepartmentId"] = new SelectList(departments, "DepartmentId", "Name");
            ViewData["Manager"] = new SelectList(managers, "EmployeeId", "Name");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmployeeId,Name,Email,Salary,PhoneNumber,IsManager,Manager,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                string response = _employeeManager.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            var departments = _departmentManager.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(departments, "DepartmentId", "Name", employee.DepartmentId);
            var managers = _employeeManager.GetManagers();
            ViewData["Manager"] = new SelectList(managers, "EmployeeId", "Name", employee.Manager);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            var departments = _departmentManager.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(departments, "DepartmentId", "Name", employee.DepartmentId);
            var managers = _employeeManager.GetManagers();
            ViewData["Manager"] = new SelectList(managers, "EmployeeId", "Name", employee.Manager);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("EmployeeId,Name,Email,Salary,PhoneNumber,IsManager,Manager,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string reponse = _employeeManager.EditEmployee(employee);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            var departments = _departmentManager.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(departments, "DepartmentId", "Name", employee.DepartmentId);
            var managers = _employeeManager.GetManagers();
            ViewData["Manager"] = new SelectList(managers, "EmployeeId", "Name", employee.Manager);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            string reponse = _employeeManager.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
