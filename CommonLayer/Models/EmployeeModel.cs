using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
