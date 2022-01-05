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
                        EditDepartaments(ref humanResourceManager);
                        break;
                    case 2.1:
                        GetEmployeList(ref humanResourceManager);
                        break;
                    case 2.2:

                        break;
                    case 2.3:
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 2.4:
                        EditEmploye(ref humanResourceManager);
                        break;
                    case 2.5:
                        Remove(ref humanResourceManager);
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
                Console.WriteLine("Department yoxdur");


            }
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine(item);
                Console.WriteLine("----------------------------------");
            }
            //Console.WriteLine("departmentlerin siayisi:\n");
            //Console.WriteLine("------------------------");
            //foreach (Department item in humanResourceManager.Departments)
            //{ 
            //        Console.WriteLine(item);
            //        Console.WriteLine("------------------------------------------------"); 
            //}
            humanResourceManager.GetDepartments();
        }
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {

            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Department yoxdur,evvelce department yaradin");
                return;
            }





            Console.WriteLine("Isci Elave edilecek Departmentin adini daxil edin");
            foreach (var item in humanResourceManager.Departments)
            {
                Console.WriteLine(item);
                Console.WriteLine("-----------------");
            }
            string Departmentname = Console.ReadLine();
            bool checkName = true;
            int count = 0;
            while (checkName)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == Departmentname.ToLower())
                    {
                        count++;
                    }
                }
                if (count < 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Department yoxdur");
                    Console.Write("Duzgun Ad Daxil Et: ");
                    Departmentname = Console.ReadLine();
                }
                else
                {
                    checkName = false;
                }
                count = 0;
            }


            Console.WriteLine("Departmente elave edilecek iscinin adini (Ad , Soyad ) daxil edin ");
        info:
            string fullname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Ad bos ola bilmez");
                Console.WriteLine("yeniden daxil edin");
                goto info;
            }

            Console.WriteLine("Elave edilecek   Iscinin  vezifesini daxil edin");
        check:
            string position = Console.ReadLine();

            while (position.Length <= 1)
            {
                Console.WriteLine("Duzgun Ad Daxil Et:");
                position = Console.ReadLine();
                goto check;
            }

            Console.WriteLine("Iscinin   maasni daxil edi n");
        checksalary:
            string salary = Console.ReadLine();
            double salarycheck;
            while (!double.TryParse(salary, out salarycheck) || salarycheck <= 249)
            {
                Console.WriteLine("Duzgun maas Daxil Et:");
                salary = Console.ReadLine();
                goto checksalary;
            }

            humanResourceManager.AddEmployee(fullname, position, salarycheck, Departmentname);

        }
        static void GetEmployeList(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Department yoxdur");
            }

            foreach (Department item in humanResourceManager.Departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2 != null && item.Employees.Length <= 0)
                    {
                        Console.WriteLine("Departmentde isci yoxdur");
                    }
                }
            }
            foreach (Department item in humanResourceManager.Departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    Console.WriteLine(item2);
                }
            }
        }
        static void EditDepartaments(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("DEYISHIKLIK ETMEK ISTEDIYINIZ DEPARTMENTIN ADINI DAXIL EDIN");
            string DepName = Console.ReadLine();
            bool res = true;
            int count = 0;
            while (res)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == DepName.ToLower())
                    {
                        count++;
                    }
                }
                if (count <= 0)
                {
                    Console.WriteLine("Daxil etdiyiniz ad sehvdir");
                    Console.WriteLine("yeniden daxil et");
                    DepName = Console.ReadLine();
                }
                else
                {
                    res = false;
                }
                count = 0;
            }
            Console.WriteLine("Yeni department adini daxil edin ");
        yeniden:
            string Newdepname = Console.ReadLine();
            int word;
            bool reqem1 = true;
            int check = 0;
            while (reqem1)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == Newdepname.ToLower())
                    {
                        check++;
                    }

                }
                if (check > 0)
                {
                    Console.WriteLine("Daxil etdiyiniz ad movcuddur");
                    Console.WriteLine("yeniden daxil edin");
                    goto yeniden;

                }
                else if (int.TryParse(Newdepname, out word))
                {
                    Console.WriteLine("reqem olmaz");
                    Console.WriteLine("yeniden daxil et");
                    goto yeniden;
                }
                else
                {
                    reqem1 = false;
                }
                check = 0;
            }

            foreach (Department item in humanResourceManager.Departments)
            {
                foreach (Employee employee in item.Employees)
                {
                    if (employee != null && employee.DepartmentName.ToLower() == DepName.ToLower())

                    {
                        employee.DepartmentName = Newdepname;
                        string substring = Newdepname.ToUpper().Substring(0, 2) + employee.No.Substring(2, 4);
                        employee.No = substring;
                    }
                }
            }
            humanResourceManager.EditDepartaments(DepName, Newdepname);
        }
        static void EditEmploye(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("DEPARTMENT BOSDUR");
                return;
            }
            Console.WriteLine("deyisiklik etmek istediyin iscinin departmentin yaz");
            foreach (var item in humanResourceManager.Departments)
            {
                Console.WriteLine(item);
            }
        yeniden2:
            string Newdepname = Console.ReadLine();
            int word;
            bool reqem1 = true;
            int check = 0;

            foreach (Department item in humanResourceManager.Departments)
            {
                if (item.Name.ToLower() == Newdepname.ToLower())
                {
                    foreach (Employee employee in item.Employees)
                    {
                        if (employee!=null)
                        {

                        }
                    }
                }

            }
            if (check > 0)
            {
                Console.WriteLine("Daxil etdiyiniz ad movcuddur");
                Console.WriteLine("yeniden daxil edin");
                goto yeniden2;

            }
            else if (int.TryParse(Newdepname, out word))
            {
                Console.WriteLine("reqem olmaz");
                Console.WriteLine("yeniden daxil et");
                goto yeniden2;
            }
            else
            {
                reqem1 = false;
            }
            check = 0;



            Console.WriteLine("deyisiklik etmek istediyin iscinin  nomresini daxil et");

        }
        static void Remove(ref HumanResourceManager humanResourceManager)
        {ad:
            string DepName = Console.ReadLine();
            bool result = true;
            int count = 0;
            while(result)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower()==DepName.ToLower())
                    {
                        count++;
                    }
                }
                if (count <= 0)
                {
                    Console.WriteLine("Duzgun departmen adi daxil edin");
                    goto ad;
                }
                else
                {
                    result = false;
                }
                count = 0;
            }
            Console.WriteLine("silinme etmek istediyinz NO-ni daxil et");
            foreach (var item in humanResourceManager.Departments)
            {
                if (item!=null && item.Name.ToLower()==DepName.ToLower())
                {
                    foreach (Employee item2 in item.Employees)
                    {
                        if (item2!=null )
                        {
                            Console.WriteLine("----------");
                            Console.WriteLine(item2);
                            Console.WriteLine("----------");
                        }
                    }
                }
            }
        one:
            string NO = Console.ReadLine();
            bool result1 = true;
            int counter = 0;
            while (result1)
            {
                foreach (var item in humanResourceManager.Departments)
                {
                    foreach (Employee employee in item.Employees)
                    {
                        if (employee!=null && employee.No.ToLower()==NO.ToLower())
                        {
                            counter++;
                        }
                    }
                }
                if (counter>0)
                {
                    result1 = false;
                }
                else
                {
                    Console.WriteLine("Duzgun No daxil et");
                    goto one;
                }
                counter=0;
            }
            humanResourceManager.RemoveEmployee(NO, DepName);
        }
    }
    }
