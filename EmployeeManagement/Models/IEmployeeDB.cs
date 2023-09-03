using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public interface IEmployeeDB
    {
        int Delete(int Id);
        List<Employee> GetData();
        int Insert(Employee model);
        int Update(Employee model);

        int InsertUsers(EmployeeUsers model);
    }
}