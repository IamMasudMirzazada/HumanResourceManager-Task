using ConsoleAppTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTask.Interfaces
{
    interface IHumanResourceManager
    {
        Employee[] Employees { get; }
          Department[] Departments { get; }

          void AddDepartment(Employee[] employees, double salaryLimit, string name, int workerLimit);

          Department[] GetDepartments(Department[] Departments);

          void EditDepartaments(string Name, string newName);

          void AddEmployee(string position, string fullname, double salary, string departmentName);

          void RemoveEmployee(string No, string DepartmentName);

          void EditEmploye(string No,string Fullname ,double Salary ,string Position);

    }
}
