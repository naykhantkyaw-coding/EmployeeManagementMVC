using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EmployeeManagement.Controllers
{
    public class AddUserController : Controller
    {
        private readonly IConfiguration _configuration;
        string connection;

        public AddUserController(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = _configuration.GetConnectionString("myConnection");
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(EmployeeUsers users)
        {
            if (!ModelState.IsValid) return BadRequest("Enter Requrired Fields");
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Insert into EmployeeUser Values('" + users.UserName + "','" + users.Password + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return this.Ok("Form User Received");

        }
    }
}
