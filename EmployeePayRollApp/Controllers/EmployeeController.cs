using System;
using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayRollApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL employeeBL;

        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(EmployeeModel employee)
        {
            try
            {
                var employeeDetail = this.employeeBL.AddEmployee(employee);
                if (employeeDetail != null)
                {
                    return this.Ok(new { Success = true, message = "Employee Added Successfully", Response = employeeDetail });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Employee Added Unsuccessfully" });
                }
            }
            catch (Exception)
            {
                throw;            }
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                var employeeDetail = this.employeeBL.UpdateEmployee(employee);
                if (employeeDetail != null)
                {
                    return this.Ok(new { Success = true, message = "Employee Detail Updated Successfully", Response = employeeDetail });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Employee Detail Updated Unsuccessfully" });
                }
            }
            catch (Exception)
            {
                throw;            
            }
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            try
            {
                var employeeDetail = this.employeeBL.DeleteEmployee(employeeId);
                if (employeeDetail)
                {
                    return this.Ok(new { Success = true, message = "Employee Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Employee Deleted Unsuccessfully" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployeeById(int employeeId)
        {
            try
            {
                var employee = this.employeeBL.GetEmployeeById(employeeId);
                if (employee != null)
                {
                    return this.Ok(new { Success = true, message = "Employee Detail Fetched Sucessfully", Response = employee });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "something went wrong" });
                }
            }
            catch (Exception)
            {
                throw;   
            }
        }


        [HttpGet("GetAllEmployee")]
        public IActionResult GetAllEmployee()
        {
            try
            {
                var employee = this.employeeBL.GetAllEmployee();
                if (employee != null)
                {
                    return this.Ok(new { Success = true, message = "Employee Detail Fetched Sucessfully", Response = employee });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "something went wrong" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
