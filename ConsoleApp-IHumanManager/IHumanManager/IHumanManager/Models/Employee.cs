using System;
using System.Collections.Generic;
using System.Text;

namespace IHumanManager.Models
{
    class Employee
    {
        public string No { get; set; }
        public string Fullname { get; set; }

        private string _fullname;
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value.Length >=2)
                {
                    _position = value;
                }
                
            }
        }
        private string _position;
        public string DepartmentName { get; set; }
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value >= 250)
                {
                    _salary = value;
                }
            }
        }
        private double _salary;
       

        public Employee(string fullname, string position, double salary, string departmentName)
        {
            Fullname = fullname;
            Position = position;
            DepartmentName = departmentName;
            Salary = salary;
            int count = 1000;
            count++;
            No = No + departmentName.ToLower().Substring(0, 2) + count;
        }
        
    }
}
