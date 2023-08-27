using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDB _employeeDB;

        public EmployeeController(IEmployeeDB employeeDB)
        {
            _employeeDB = employeeDB;
        }

        public IActionResult Index()
        {
            List<Employee> employeeList = _employeeDB.GetData();
            return View(employeeList);
        }

        public IActionResult Details(int Id)
        {
            var data = GetById(Id);
            return View(data);
        }

        public Employee GetById(int Id)
        {
            var result = _employeeDB.GetData().Find(x => x.Id == Id);
            return result;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(collection["Id"].ToString());
                employee.EmployeeName = collection["EmployeeName"].ToString();
                employee.Office = collection["Office"].ToString();
                employee.Position = collection["Position"].ToString();
                employee.Salary = Convert.ToInt32(collection["Salary"].ToString());
                int result = _employeeDB.Insert(employee);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int Id)
        {
            var data = GetById(Id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, IFormCollection collection)
        {
            try
            {
                Employee employee = new Employee();
                employee.Id = Id;
                employee.EmployeeName = collection["EmployeeName"].ToString();
                employee.Office = collection["Office"].ToString();
                employee.Position = collection["Position"].ToString();
                employee.Salary = Convert.ToInt32(collection["Salary"].ToString());
                int result = _employeeDB.Update(employee);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int Id)
        {
            var data = GetById(Id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id, IFormCollection collection)
        {
            try
            {
                int result = _employeeDB.Delete(Id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
