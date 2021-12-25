using ConsoleAppTask.Models;
using ConsoleAppTask.Services;
using System;

namespace ConsoleAppTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {  
                Console.WriteLine("-----------------------------IHumanResourceManager ---------------------------");
                Console.WriteLine("Etmek istediyiniz emeliyyatin qarshinsindaki reqemi daxil edin");
                Console.WriteLine("1.1 - Departameantlerin siyahisini gostermek");
                Console.WriteLine("1.2 - Departamenet yaratmaq");
                Console.WriteLine("1.3 - Departmanetde deyisiklik etmek");
                Console.WriteLine("2.1 - Iscilerin siyahisini gostermek ");
                Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("2.3 - Isci elave etmek ");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departamentden isci silinmesi ");
                Console.WriteLine("Daxil et: ");
                string choose = Console.ReadLine();
                double chooseNum = 0;
                double.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1.1:
                         
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 1.2:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 1.3:
                        Console.Clear();
                        EditDepartaments(ref humanResourceManager);
                        break;
                    case 2.1:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 2.2:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 2.3:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 2.4:
                        Console.Clear();
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 2.5:
                        Console.Clear();
                        RemoveEmployee(ref humanResourceManager);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun Daxil Et");
                        break;
                }
            }
            while (true);
        }

        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Departmentin adini daxil et");
        check:
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ad soyadi duzgun daxil edin");
                goto check;
            }

            Console.WriteLine("Max isci sayini daxil et");
            string WorkerLimit = Console.ReadLine();
            int WorkerLimitNum = 0;
            while (!int.TryParse(WorkerLimit, out WorkerLimitNum) || WorkerLimitNum <= 0)
            {
                Console.WriteLine("Duzgun daxil et");
                WorkerLimit = Console.ReadLine();
            }

            Console.WriteLine("SalaryLimit-i  Daxil et");
            string salaryLimit = Console.ReadLine();
            double salaryLimitNum = 0;
            while (!double.TryParse(salaryLimit, out salaryLimitNum) || salaryLimitNum < 250)
            {
                Console.WriteLine(" MEBLEGI Duzgun daxil et");
                salaryLimit = Console.ReadLine();
            }
            humanResourceManager.AddDepartment(humanResourceManager.Employees, salaryLimitNum, name, WorkerLimitNum);

        }
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("ELave etmek istediyiniz iscinin  Fullname-ni daxil et");
        checkfullname:
            string fullname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Ad soyadi duzgun daxil edin");
                goto checkfullname;
            }


            Console.WriteLine("ELave etmek istediyiniz iscinin maas-ni daxil et");
        tryagain:
            string salary = Console.ReadLine();
            double salaryNum = 0;
            while (!double.TryParse(salary, out salaryNum) || salaryNum < 250)
            {
                Console.WriteLine("Duzgun daxil et");
                goto tryagain;
            }

            Console.WriteLine("Elave olunacaqi departmentin adi");
        checkDepartment:
            string departmentName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(departmentName))
            {
                Console.WriteLine(" Department adini duzgun daxil edin");
                goto checkDepartment;
            }

            Console.WriteLine("ELave etmek istediyiniz iscinin vezifesini daxil et");
        checkposition:
            string position = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(position))
            {
                Console.WriteLine("Elave edilin iscinin vezife adini duzgun daxil edin");
                goto checkposition;
            }
            humanResourceManager.AddEmployee(fullname, position, salaryNum, departmentName);
        }
        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            foreach (var item in humanResourceManager.Departments)
            {
                Console.WriteLine(item);
            }
        }
        static void EditDepartaments(ref HumanResourceManager humanResourceManager)
        {

        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {

        }
        static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Employee item in humanResourceManager.Employees)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("duzelis etmek isdeyiniz iscinin nomresini daxil edin");
            string employeNo = Console.ReadLine();
            bool checkemployeeNo = true;
            int count = 0;
            while (checkemployeeNo)
            {
                foreach (Employee item in humanResourceManager.Employees)
                {
                    if (item.No.ToLower() == employeNo.ToLower())
                    {
                        count++;
                    }
                }
                if (count <= 0)
                {
                    Console.WriteLine("Duzgun menu nomresi daxil edin");
                    employeNo = Console.ReadLine();

                }
                else
                {
                    checkemployeeNo = false;
                }
                count = 0;

            }

        }
    }
}
