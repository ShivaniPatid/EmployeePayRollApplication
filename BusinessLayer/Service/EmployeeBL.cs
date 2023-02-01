using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using CommonLayer.Models;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            try
            {
                return this.employeeRL.AddEmployee(employee);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public EmployeeModel UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                return this.employeeRL.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                return this.employeeRL.DeleteEmployee(employeeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            try
            {
                return this.employeeRL.GetEmployeeById(employeeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EmployeeModel> GetAllEmployee()
        {
            try
            {
                return this.employeeRL.GetAllEmployee();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
