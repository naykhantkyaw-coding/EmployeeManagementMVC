using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement.Models
{

    public class EmployeeDB : IEmployeeDB
    {
        private readonly IConfiguration _configuration;
        string Connection;
        public EmployeeDB(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = _configuration.GetConnectionString("myConnection");
        }

        public List<Employee> GetData()
        {
            List<Employee> data = new List<Employee>();
            SqlConnection con = new SqlConnection(Connection);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SelectEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(new Employee
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        EmployeeName = reader["EmployeeName"].ToString(),
                        Position = reader["Position"].ToString(),
                        Office = reader["Office"].ToString(),
                        Salary = Convert.ToInt32(reader["Salary"].ToString())
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }

        public int InsertUsers(EmployeeUsers users)
        {
            SqlConnection con = new SqlConnection(Connection);
            int result;
            try
            {
                con.Open();
                string query = "Insert into EmployeeUser Values('" + users.UserName + "','" + users.Password + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public int Insert(Employee model)
        {
            SqlConnection con = new SqlConnection(Connection);
            int result;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertUpdatedEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.Parameters.AddWithValue("@employeename", model.EmployeeName);
                cmd.Parameters.AddWithValue("@position", model.Position);
                cmd.Parameters.AddWithValue("@office", model.Office);
                cmd.Parameters.AddWithValue("@salary", model.Salary);
                cmd.Parameters.AddWithValue("@action", "Insert");
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public int Update(Employee model)
        {
            SqlConnection con = new SqlConnection(Connection);
            int result;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertUpdatedEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.Parameters.AddWithValue("@employeename", model.EmployeeName);
                cmd.Parameters.AddWithValue("@position", model.Position);
                cmd.Parameters.AddWithValue("@office", model.Office);
                cmd.Parameters.AddWithValue("@salary", model.Salary);
                cmd.Parameters.AddWithValue("@action", "Update");
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public int Delete(int Id)
        {
            SqlConnection con = new SqlConnection(Connection);
            int result;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Id);
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }




    }
}
