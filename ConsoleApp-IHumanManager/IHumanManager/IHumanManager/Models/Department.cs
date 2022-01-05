using System;
using System.Collections.Generic;
using System.Text;

namespace IHumanManager.Models
{
    class Department
    {
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 2)
                {
                    return;
                }
                _name = value;
            }
        }
        private string _name;
        public int WorkerLimit
        {
            get
            {
                return _workerLimit;
            }
            set
            {
                if (value >= 1)
                {
                    _workerLimit = value;
                }

            }
        }
        private int _workerLimit;
        public double SalaryLimit
        {
            get
            {
                return _salaryLimit;
            }
            set
            {
                if (value >= 250)
                {
                    _salaryLimit = value;
                }

            }
        }
        private double _salaryLimit;

        public Employee[] Employees = { };
        public Department(string name, int workerLimit, double salaryLimit)
        {
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;

            Employees = new Employee[0];
        }
        public double CalcSalaryAverage()
        {
            double totalAmount = 0;
            int count = 0;
            foreach (Employee item in Employees)
            {
                if (item!=null)
                {
                    count++;
                    totalAmount = totalAmount + item.Salary;
                }
            
            }
            if (count<=0)
            {
                return 0;
            }
            else
            {
                return totalAmount / count;
            }
            

	}
        public override string ToString()
        {
            return $"Name: {Name} \nWorker Limit: {WorkerLimit} \nSalary Limit:{SalaryLimit}";
        }
    }
            
            
            
 
}
