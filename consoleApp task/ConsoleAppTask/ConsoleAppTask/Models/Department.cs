using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTask.Models
{
    class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public Employee Employee { get; set; }
        public Employee [] Employees { get; set; }
        private static int Count = 0;
        //public int CalcSalaryAverage()

        public Department(Employee[] employees,double salaryLimit, string name, int workerLimit)
        {
            Employees = employees;
            SalaryLimit = salaryLimit;
            Name = name;
            WorkerLimit = workerLimit; 
        }
        public double CalcSalaryAverage(Department department)
        {
            double totalSalary = 0;
            Count++;
            foreach (Employee item in Employees)
            {
                totalSalary += item.Salary;
                Count++;
            }
            return totalSalary / Count;
        }
       


    }
}
