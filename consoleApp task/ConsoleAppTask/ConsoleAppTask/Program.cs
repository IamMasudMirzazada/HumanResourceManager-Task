using ConsoleAppTask.Models;
using ConsoleAppTask.Services;
using System;

namespace ConsoleAppTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("programmer","Mesud Mirzezde",1500,"IT");
            Employee emp2 = new Employee("DIZaYENeR ", "Farid Aliyev", 2500, "DZ");
            Employee emp3 = new Employee("Muhasib", "Sexaver Aliyev", 3500, " MH");
            Employee emp4 = new Employee("marketinq", "Kamil Kamilov", 4500, "MR");

            Employee[] Employees = { emp1, emp2, emp3, emp4 };

            Department dep = new Department(Employees,6000,"ITDEPARTMENT",20);


            HumanResourceManager humanResourceManager = new HumanResourceManager();
            humanResourceManager.RemoveEmployee();

            humanResourceManager.AddDepartment(Employees, 500, "IT", 10);

        }
        
    }
}
