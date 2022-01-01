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
                if (value >=1)
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
       
        public Employee[] Employees;
        public Department(string name, int workerLimit,double salaryLimit)
        {
            Name = Name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;

            Employees = new Employee[0];
        }
        //CalcSalaryAverage()
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
