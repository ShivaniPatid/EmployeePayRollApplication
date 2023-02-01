using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Models;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public EmployeeModel AddEmployee(EmployeeModel employee);
        public EmployeeModel UpdateEmployee(EmployeeModel employee);
        public bool DeleteEmployee(int employeeId);
        public EmployeeModel GetEmployeeById(int employeeId);
        public List<EmployeeModel> GetAllEmployee();
    }
}
