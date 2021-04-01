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
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentManager _departmentManager;
        public DepartmentsController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        // GET: Departments
        public IActionResult Index()
        {
            var departments = _departmentManager.GetDepartments();
            return View(departments);
        }

        // GET: Departments/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var department = _departmentManager.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DepartmentId,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                string response = _departmentManager.AddDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var department = _departmentManager.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([Bind("DepartmentId,Name")] Department department)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string reponse = _departmentManager.EditDepartment(department);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var department = _departmentManager.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            string reponse = _departmentManager.DeleteDepartment(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
