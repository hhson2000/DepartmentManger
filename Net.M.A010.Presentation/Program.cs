using Net.M.A010.Models;
using System;

namespace Net.M.A010.Presentation
{
    internal class Program
    {
        private static DepartmentManage departmentManager = new DepartmentManage();

        private static void Main(string[] args)
        {
            //Menu Options
            while (true)
            {
                Console.WriteLine("=== Menu Option ===");
                Console.WriteLine("1. Input data from the keyboard:");
                Console.WriteLine("2. Display employees: ");
                Console.WriteLine("3. Classify employees: ");
                Console.WriteLine("4. Employee Search:");
                Console.WriteLine("5. Report:");
                Console.Write("Enter number of option:");
                int choose = Validation.checkLimit(5, 1);
                switch (choose)
                {
                    case 1:
                        CreateEmployees();
                        break;

                    case 2:
                        DisplayEmployee();
                        break;

                    case 3:
                        DisplayEmployee();
                        break;

                    case 4:
                        EmployeeSearch();
                        break;

                    case 5:
                        Info();
                        break;

                    default:
                        break;
                }
            }
        }

        //Create
        private static void CreateEmployees()
        {
            departmentManager.AddDepartment();
        }

        //Display
        private static void DisplayEmployee()
        {
            departmentManager.DisplayEmployee();
        }

        //Search
        private static void EmployeeSearch()
        {
            int choose = -1;
            do
            {
                Console.WriteLine("===Choose options===");
                Console.WriteLine("1. Display employees by department name.");
                Console.WriteLine("2. Display detail information's employee by employee name.");
                Console.WriteLine("0. Exit");
                Console.Write("Enter number of option:");
                Int32.TryParse(Console.ReadLine(), out choose);
                switch (choose)
                {
                    case 1:
                        SearchByDepartment();
                        break;

                    case 2:
                        SearchByEmployeeName();
                        break;

                    default:
                        break;
                }
            } while (choose != 0);
        }

        //Search by department
        private static void SearchByDepartment()
        {
            Console.Write("Department name: ");
            string departmentName = Console.ReadLine();
            departmentManager.DisplayEmployeesByDepartment(departmentName);
        }

        //Search by name
        private static void SearchByEmployeeName()
        {
            Console.Write("Employee name: ");
            string employeeName = Console.ReadLine();
            departmentManager.DisplayEmployee(employeeName);
        }

        //Diplay info
        private static void Info()
        {
            departmentManager.NumberOfEmployee();
        }
    }
}