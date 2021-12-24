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
          
            if (employees.Length <= 0)
            {
                Console.WriteLine("Isci sayi minimum 1  ola  biler");
                return;
            }

            if (salaryLimit < 250)
            {
                Console.WriteLine("Verilen maas 250-den kicik ola bilmez");
                return;
            }
            if (name.Length < 2)
            {
                Console.WriteLine(" departament adi minimum 2 herfden ibaret olmalidir");
                return;
            }
            


        }
        //public override string ToString()
        //{
        //    return $"{Fullname} {Position} {Salary} {DepartmentName}";
        //}



    }
}
