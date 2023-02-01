using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class EmployeeRL : IEmployeeRL
    {
        private static SqlConnection sqlConnection;
        private readonly IConfiguration configuration;

        public EmployeeRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            try
            {
                sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayRollDB"]);
                SqlCommand cmd = new SqlCommand("AddEmployee", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                sqlConnection.Open();
                int i = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if(i >= 1)
                {
                    return employee;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public EmployeeModel UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayRollDB"]);
                SqlCommand cmd = new SqlCommand("UpdateEmployee", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                sqlConnection.Open();
                int i = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (i >= 1)
                {
                    return employee;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayRollDB"]);
                SqlCommand cmd = new SqlCommand("DeleteEmployee", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                sqlConnection.Open();
                int i = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayRollDB"]);
                SqlCommand cmd = new SqlCommand("GetEmployeeById", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                sqlConnection.Open();
                EmployeeModel employeeModel = new EmployeeModel();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        employeeModel.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employeeModel.EmployeeName = reader["EmployeeName"].ToString();
                        employeeModel.ProfileImage = reader["ProfileImage"].ToString();
                        employeeModel.Gender = reader["Gender"].ToString();
                        employeeModel.Department = reader["Department"].ToString();
                        employeeModel.Salary = Convert.ToInt32(reader["Salary"]);
                        employeeModel.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        employeeModel.Notes = reader["Notes"].ToString();
                    }
                    sqlConnection.Close();
                    return employeeModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<EmployeeModel> GetAllEmployee()
        {
            try
            {
                List<EmployeeModel> employee = new List<EmployeeModel>();
                sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayRollDB"]);
                SqlCommand cmd = new SqlCommand("GetAllEmployee", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        EmployeeModel employeeModel = new EmployeeModel();
                        employeeModel.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employeeModel.EmployeeName = reader["EmployeeName"].ToString();
                        employeeModel.ProfileImage = reader["ProfileImage"].ToString();
                        employeeModel.Gender = reader["Gender"].ToString();
                        employeeModel.Department = reader["Department"].ToString();
                        employeeModel.Salary = Convert.ToInt32(reader["Salary"]);
                        employeeModel.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        employeeModel.Notes = reader["Notes"].ToString();
                        employee.Add(employeeModel);
                    }
                    return employee;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }


    }
}
