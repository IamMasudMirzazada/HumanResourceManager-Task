using IHumanManager.Models;
using IHumanManager.Services;
using System;

namespace IHumanManager
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            while (true)
            {
                Console.WriteLine(" - Etmek istediyiniz emeliyyatin qarshisindaki ededi daxil edin ");
                Console.WriteLine("1.1 - Departameantlerin siyahisini gostermek ");
                Console.WriteLine("1.2 - Departamenet yaratmaq");
                Console.WriteLine("1-3 - Departmanetde deyisiklik etmek");
                Console.WriteLine("2.1 - Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departamentden isci silinmesi");
                string no = Console.ReadLine();
                double select = 0;
                double.TryParse(no, out select);
                switch (select)
                {
                    case 1.1:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 1.2:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 1.3:
                        //EditDepartaments(ref humanResourceManager);
                        break;
                    case 2.1:

                        break;
                    case 2.2:

                        break;
                    case 2.3:

                        break;
                    case 2.4:
                        //EditEmploye(ref humanResourceManager);
                        break;
                    case 2.5:

                        break;
                    default:
                        Console.WriteLine("duzgun eded daxil edin");
                        break;
                }
            }
        }
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Elave edilecek Departmentin adini daxil edin");

            string name = Console.ReadLine();
            bool checkName = true;
            int count = 0;
            while (checkName)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == name.ToLower())
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Department Artiq Movcuddur");
                    Console.Write("Duzgun Ad Daxil Et: ");
                    name = Console.ReadLine();
                }
                else
                {
                    checkName = false;
                }
                count = 0;
            }

            Console.WriteLine("Elave edilecek max Isci sayini daxil edin");    
            string workerLimit = Console.ReadLine();
            int workerLimitcheck;
            while (!int.TryParse(workerLimit, out workerLimitcheck) || workerLimitcheck <= 0)
            {
                Console.WriteLine("Duzgun Qiymet Daxil Et:");
                workerLimit = Console.ReadLine();
            }

            Console.WriteLine("Iscinin maksimum maasni daxil edi n");
            string salaryLimit = Console.ReadLine();
            double salaryLimitcheck;
            while (!double.TryParse(salaryLimit, out salaryLimitcheck) || salaryLimitcheck <= 249)
            {
                Console.WriteLine("Duzgun maas Daxil Et:");
                salaryLimit = Console.ReadLine();
            }

            humanResourceManager.AddDepartment(name, workerLimitcheck, salaryLimitcheck);
        }
        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.Clear();    
                Console.WriteLine("Department yoxdur");
                return;
            }
            Console.WriteLine("departmentlerin siayisi:\n");
            Console.WriteLine("------------------------");
            foreach (Department item in humanResourceManager.Departments)
            { 
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------------------------"); 
            }
            humanResourceManager.GetDepartments();
        }

        //    //static void AddEmployee();
        //    static void EditEmploye();
        //    //static void RemoveEmployee();
        //    static void EditDepartaments();

        //}
    }
}