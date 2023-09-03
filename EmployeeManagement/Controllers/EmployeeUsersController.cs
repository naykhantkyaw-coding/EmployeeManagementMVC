using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace EmployeeManagement.Controllers
{
    public class EmployeeUsersController : Controller
    {
        private readonly IEmployeeDB _db;

        public EmployeeUsersController(IEmployeeDB db)
        {
            _db = db;
        }

        public IActionResult CreateUsers()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUsers(IFormCollection collection)
        {
            try
            {
                EmployeeUsers users = new EmployeeUsers();
                users.UserName = collection["UserName"].ToString();
                users.Password = collection["Password"].ToString();
                _db.InsertUsers(users);
                return RedirectToAction("Index","Employee");

            }
            catch 
            {
                return View();
            }
        }


    }
}
