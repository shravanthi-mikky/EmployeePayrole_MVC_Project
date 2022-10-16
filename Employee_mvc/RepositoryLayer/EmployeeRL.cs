using Employee_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Employee_mvc.RepositoryLayer
{
    public class EmployeeRL : IEmployeeRL
    {
        SqlConnection sqlConnection;
        string ConnString = "Data Source=LAPTOP-2UH1FDRP\\MSSQLSERVER01;Initial Catalog=Employ_mvc;Integrated Security=True;";

        public EmployeeModel AddEmployee(EmployeeModel emp)
        {
            try
            {
                using (sqlConnection = new SqlConnection(ConnString))
                {
                    SqlCommand com = new SqlCommand("Sp_AddEmployee", sqlConnection);
                    com.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlConnection.Open();

                    //com.Parameters.AddWithValue("@Name", emp.EmployeeId);
                    com.Parameters.AddWithValue("@Name", emp.Name);
                    com.Parameters.AddWithValue("@Profile", emp.Profile);
                    com.Parameters.AddWithValue("@Gender", emp.Gender);
                    com.Parameters.AddWithValue("@Department", emp.Department);
                    com.Parameters.AddWithValue("@Salary", emp.Salary);
                    com.Parameters.AddWithValue("@StartDate", emp.StartDate);

                    com.ExecuteNonQuery();
                    return emp;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Update

        public EmployeeModel UpdateBook(EmployeeModel emp)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnString);
                using (conn)
                {

                    SqlCommand com = new SqlCommand("spUpdateEmployee", conn);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                    com.Parameters.AddWithValue("@Name", emp.Name);
                    com.Parameters.AddWithValue("@Profile", emp.Profile);
                    com.Parameters.AddWithValue("@Gender", emp.Gender);
                    com.Parameters.AddWithValue("@Department", emp.Department);
                    com.Parameters.AddWithValue("@Salary", emp.Salary);
                    com.Parameters.AddWithValue("@StartDate", emp.StartDate);

                    conn.Open();
                    int i = com.ExecuteNonQuery();
                    conn.Close();
                    if (i >= 1)
                    {
                        return emp;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Get all

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            SqlConnection conn = new SqlConnection(ConnString);
            using (conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employees.Add(new EmployeeModel
                            {
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                Name = reader["Name"].ToString(),
                                Profile = reader["Profile"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Department = (reader["Department"]).ToString(),
                                Salary = (reader["Salary"]).ToString(),
                                StartDate = ((DateTime)reader["StartDate"]),
                            });
                        }
                        return employees;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        //Delete Employee

        public bool DeleteBook(EmployeeIdModel employeeDeleteModel)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand com = new SqlCommand("Sp_Delete", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeId", employeeDeleteModel.EmployeeId);

            conn.Open();
            int i = com.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        //Get employee by ID

        public object Retrive_Employee_Details(EmployeeIdModel employeeIdModel)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand com = new SqlCommand("Retrive_1_BookDetails", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@bookId", employeeIdModel.EmployeeId);
            conn.Open();
            EmployeeModel emp_model = new EmployeeModel();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    emp_model.EmployeeId = Convert.ToInt32(rd["EmployeeId"]);
                    emp_model.Name = rd["Name"].ToString();
                    emp_model.Profile = rd["Profile"].ToString();
                    emp_model.Gender = rd["Gender"].ToString();
                    emp_model.Department = (rd["Department"]).ToString();
                    emp_model.Salary = (rd["Salary"]).ToString();
                    emp_model.StartDate = ((DateTime)rd["StartDate"]);
                }
                return emp_model;
            }
            return null;
        }

    }
}
