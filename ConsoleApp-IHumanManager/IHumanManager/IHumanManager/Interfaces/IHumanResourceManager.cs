using IHumanManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHumanManager.Interfaces
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        void AddDepartment(string name, int workerLimit,double salaryLimit);
        Department[] GetDepartments(); 
        void EditDepartaments(string name,string newname);
        void EditEmploye(  string position, double salary, string no);
        void AddEmployee(string fullname, string position, double salary, string departmentName);
        void RemoveEmployee(string no, string departmentName);
 
    }
}
