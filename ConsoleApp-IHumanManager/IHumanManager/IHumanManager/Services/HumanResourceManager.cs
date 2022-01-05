using IHumanManager.Interfaces;
using IHumanManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHumanManager.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;
        
        public HumanResourceManager()
        {
            _departments = new Department[0];
        }
        public void AddDepartment(string name, int workerLimit, double salaryLimit)
        { 
            Department department = new Department(name, workerLimit, salaryLimit);
                Array.Resize(ref _departments, _departments.Length + 1);
                _departments[_departments.Length - 1] = department;
            
        }
        public void AddEmployee(string fullname, string position, double salary, string departmentName)
        {
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    Employee employee = new Employee(fullname, position, salary, departmentName);
                    Array.Resize(ref item.Employees, item.Employees.Length + 1);
                    item.Employees[item.Employees.Length - 1] = employee;
                }
            }
        }
        public void EditDepartaments(string name, string newname)
        {
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    item.Name = newname;
                    break;
                }
            }
        }
        public void EditEmploye( string position, double salaryLimit, string no)
        {
            //Department department = null;

            //foreach (Department item in _departments)
            //{
            //    if (item.Employees == _departments.)
            //    {
            //        department = item;
            //        break;
            //    }
            //}

            //department.Name = name;
        }
        public void RemoveEmployee(string no, string departmentName)
        {
        }
        public Department[] GetDepartments( )
        {


            Department[] departments = new Department[0];
            foreach (Department item in _departments)
            {
                if (item != null)
                {
                    Array.Resize(ref departments, departments.Length + 1);
                    departments[departments.Length - 1] = item;
                }
            }
            return departments;
        }
    }
}