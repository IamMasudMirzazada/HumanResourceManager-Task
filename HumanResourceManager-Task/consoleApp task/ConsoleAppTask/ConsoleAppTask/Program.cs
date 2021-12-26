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

            string ans;
            do
            {
                Console.WriteLine("\n==============================================\n");

                Console.WriteLine("1.1 - Departmentlerin siyahisini goster");
                Console.WriteLine("1.2 - Yeni department yaratmaq");
                Console.WriteLine("1.3 - Department adinda deyisiklik etmek");
                Console.WriteLine("2.1 - Butun iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 - Departmentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departmenden silmek istediyiniz iscinin adini yazin");
                Console.WriteLine("2.6 - Axtaris");
                Console.WriteLine("3 - sistemden cixis");

                Console.WriteLine("\nIcra etmek istediyiniz emeliyyati secin:");
                ans = Console.ReadLine();

                Console.WriteLine("\n==============================================\n");

                switch (ans)
                {
                    case "1.1":
                        ShowDepartments(humanResourceManager);
                        break;
                    case "1.2":
                        AddDepartment(humanResourceManager);
                        break;
                    case "1.3":
                        EditDepartment(humanResourceManager);
                        break;
                    case "2.1":
                        ShowAllEmployees(humanResourceManager);
                        break;
                    case "2.2":
                        ShowEmployeesOfDepartment(humanResourceManager);
                        break;
                    case "2.3":
                        AddEmployee(humanResourceManager);
                        break;
                    case "2.4":
                        EditEmployee(humanResourceManager);
                        break;
                    case "2.5":
                        RemoveEmployee(humanResourceManager);
                        break;
                    case "2.6":
                        SearchEmployee(humanResourceManager);
                        break;
                    default:
                        break;
                }

            } while (ans != "3");


        }

        static void ShowDepartments(HumanResourceManager humanResourceManager)
        {
             
        }
        static void AddDepartment(HumanResourceManager humanResourceManager)
        {
            
        }
        static void EditDepartment(HumanResourceManager humanResourceManager)
        {
           

        }
        static void ShowAllEmployees(HumanResourceManager humanResourceManager)
        {
            

        }
        static void ShowEmployeesOfDepartment(HumanResourceManager humanResourceManager)
        {
            
        }
        static void AddEmployee(HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Sistemde hec bir department movcud deyil");
            }
            else
            {
                string departmentname;
                Department department = null;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Isci elave etmek istediyiniz departmenti daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    departmentname = Console.ReadLine();
                    department = humanResourceManager.FindDepartmentByName(departmentname);
                    check = false;

                } while (department == null);

                if (department.WorkerLimit <= department.Employees.Length)
                {
                    Console.WriteLine("Departmentin isci limiti doludur, isci elave ede bilmezsiniz!");

                    return;
                }

                string fullname;
                check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Iscinin tam adini (ad, soyad seklinde) daxil edin:");
                    else
                        Console.WriteLine("Tam adi duzgun daxil edin");

                    fullname = Console.ReadLine();
                    check = false;

                } while (!humanResourceManager.CheckFullName(fullname));

                string position;
                check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Iscinin vezifesini daxil edin:");
                    else
                        Console.WriteLine("Vezife adi boyuk herfnen baslamali ve reqem olmamalidir, yeniden daxil edin");

                    position = Console.ReadLine();
                    check = false;

                } while (!humanResourceManager.CheckName(position));

                double salary;
                string salarystr;
                check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Iscinin maasini daxil edin:");
                    else
                        Console.WriteLine("Maas yazarken herf olmamalidir ve maas 250den asagi olmamalidir, yeniden daxil edin");

                    salarystr = Console.ReadLine();
                    check = false;

                } while (!double.TryParse(salarystr, out salary) || salary < 250);

                if (department.TotalSalary(department) + salary > department.SalaryLimit)
                {
                    Console.WriteLine("Elave etmek istediyiniz iscinin maasi toplam limitten artiqdir");
                    return;
                }

                humanResourceManager.AddEmployee(departmentname, fullname, position, salary);
            }


        }
        static void EditEmployee(HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hec bir department ve isci movcud deyil");
            }
            else
            {
                string departmentname;
                Department department = null;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Deyisdirmek istediyiniz iscinin departmentini daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    departmentname = Console.ReadLine();
                    department = humanResourceManager.FindDepartmentByName(departmentname);
                    check = false;

                } while (department == null);

                if (department.Employees.Length <= 0)
                {
                    Console.WriteLine("====================================================\n");
                    Console.WriteLine("Daxil etdiyiniz departmentde hecbir isci movcud deyil");
                    return;
                }
                else
                {
                    string no;
                    check = true;
                    do
                    {
                        if (check)
                            Console.WriteLine("Iscinin nomresini daxil edin:");
                        else
                            Console.WriteLine("Daxil etdiyiniz nomre yanlisdir, yeniden daxil edin");

                        no = Console.ReadLine();
                        check = false;

                        foreach (var item in department.Employees)
                        {
                            if (item.No == no)
                            {
                                Console.WriteLine($"Iscinin tam adi: {item.FullName} - Iscinin vezifesi: {item.Position} - Iscinin maasi: {item.Salary} ");
                                check = true;

                            }


                        }


                    } while (check == false);

                    string position;
                    check = true;
                    do
                    {
                        if (check)
                            Console.WriteLine("Iscinin yeni vezifesini daxil edin:");
                        else
                            Console.WriteLine("Vezife adinda reqem olmamalidir, yeniden daxil edin");

                        position = Console.ReadLine();
                        check = false;

                    } while (!humanResourceManager.CheckName(position));

                    double salary;
                    string salarystr;
                    check = true;
                    do
                    {

                        if (check)
                            Console.WriteLine("Iscinin yeni maasini daxil edin:");
                        else
                            Console.WriteLine("Maas yazarken herf olmamalidir ve maas 250den asagi olmamalidir, yeniden daxil edin");

                        salarystr = Console.ReadLine();
                        check = false;

                    } while (!double.TryParse(salarystr, out salary) || salary < 250);

                    humanResourceManager.EditEmployee(departmentname, no, position, salary);

                }

            }

        }
        static void RemoveEmployee(HumanResourceManager humanResourceManager)
        {

            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hec bir department ve isci movcud deyil");
            }
            else
            {
                string departmentname;
                Department department = null;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Silmek istediyiniz iscinin departmentini daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    departmentname = Console.ReadLine();
                    department = humanResourceManager.FindDepartmentByName(departmentname);
                    check = false;

                } while (department == null);

                if (department.Employees.Length <= 0)
                {
                    Console.WriteLine("====================================================\n");
                    Console.WriteLine("Daxil etdiyiniz departmentde hecbir isci movcud deyil");
                    return;
                }
                else
                {
                    string no;
                    check = true;
                    do
                    {
                        if (check)
                            Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil edin:");
                        else
                            Console.WriteLine("Daxil etdiyiniz nomre yanlisdir, yeniden daxil edin");

                        no = Console.ReadLine();
                        check = false;

                        foreach (var item in department.Employees)
                        {
                            if (item.No == no)
                            {
                                check = true;

                            }


                        }

                    } while (check == false);

                    humanResourceManager.RemoveEmployee(no, departmentname);
                }


            }
        }
        static void SearchEmployee(HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                string search;

                do
                {
                    Console.WriteLine("Axtaris deyerini daxil edin:");
                    search = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(search));

                var searchedEmployees = humanResourceManager.SearchEmployee(search);

                if (searchedEmployees.Length > 0)
                {
                    Console.WriteLine("Axtarisa uygun isciler: \n");
                    foreach (var item in searchedEmployees)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("====================================================\n");
                    Console.WriteLine("Axtarisa uygun isci tapilmadi!");
                }
            }
            else
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hecbir department ve isci movcud deyil");
            }

        }

    }
}
    
