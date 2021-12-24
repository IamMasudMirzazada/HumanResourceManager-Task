using ConsoleAppTask.Interfaces;
using ConsoleAppTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTask.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Employee[] Employees  => _employee;
        private Employee[] _employee;

        public Department[] Departments => _department;
        private Department[] _department;
        public HumanResourceManager()
        {
            _employee = new Employee[0];
            _department = new Department[0];

        }
        public void AddDepartment(Employee[] employees, double salaryLimit, string name, int workerLimit )
        {
            Department department = new Department(  employees,   salaryLimit,   name,   workerLimit);
            Array.Resize(ref _department, _department.Length + 1);
            _department[_department.Length - 1] = department;
        }

        public void AddEmployee(string position, string fullname, double salary, string departmentName)
        {
            Employee employee = new Employee(  position,   fullname,    salary,   departmentName);
            Array.Resize(ref _employee, _employee.Length + 1);
            _employee[_employee.Length - 1] = employee;
        }

        public void EditDepartaments(string Name, string newName)
        {
            //Department department = null;
            foreach (Department item in _department)
            {
                if (item.Name==Name)
                {
                    Name = newName;
                    break;
                }
            }
            //?
        }
  
        public void RemoveEmployee(string No, string DepartmentName)
        {
            for (int i = 0; i < _employee.Length; i++)
            {
                if (_employee[i].No==No)
                {
                    _employee = null;
                    return;
                }
            }
        }

        public Department[] GetDepartments(Department[] Departments)
        {
            return Departments;


        }

        public void EditEmploye(string No, string Fullname, double Salary, string Position)
        {
            foreach (Employee item in _employee)
            {
                if (item.No == No)
                {

                    item.Fullname = Fullname;
                    item.Salary = Salary;
                    item.Position = Position;
                }
            }
        }
    }
}
