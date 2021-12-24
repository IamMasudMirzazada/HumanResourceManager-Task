using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTask.Models
{
    class Employee
    {
        private static int Count = 1000;
        public string No { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string DepartmentName { get; set; }

        public Employee(string position, string fullname, double  salary, string departmentName)
        {
            Fullname = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;
        }
        public override string ToString()
        {
            return $"{Fullname} {Position} {Salary} {DepartmentName}";
        }
    }
}
