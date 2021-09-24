using Net.M.A010.Models;
using Net.M.A010.Models.Entities;
using Net.M.A010.Services;
using System;
using System.Collections.Generic;

namespace Net.M.A010.Presentation
{
    public class DepartmentManage
    {
        private EmployeeService _employeeService;
        private List<Employee> employees = new List<Employee>();
        private List<Department> departments = new List<Department>();

        public DepartmentManage()
        {
            _employeeService = new EmployeeService();
        }

        /// <summary>
        /// add new department
        /// </summary>
        public void AddDepartment()
        {
            var department = new Department();
            Console.Write("Department name: ");
            department.Name = Console.ReadLine();
            department.Employees = AddEmployee();
            departments.Add(department);
        }

        /// <summary>
        /// create new Hourly employeee
        /// </summary>
        public void createHourlyEmployee()
        {
            var employee = new HourlyEmployee();
            Console.Write("SSN: ");
            employee.Ssn = Console.ReadLine();
            Console.Write("FirstName: ");
            employee.FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            employee.LastName = Console.ReadLine();
            Console.Write("BirthDate: ");
            employee.BirthDate = Console.ReadLine();
            Console.Write("Phone: ");
            employee.Phone = Console.ReadLine();
            Console.Write("Email: ");
            employee.Email = Console.ReadLine();
            Console.Write("Wage: ");
            employee.Wage = Convert.ToDouble(Console.ReadLine());
            Console.Write("Workinghours: ");
            employee.WorkingHours = Convert.ToDouble(Console.ReadLine());

            employees.Add(employee);
            _employeeService.AddEmployee(employee);
        }

        /// <summary>
        /// create new salaried employee
        /// </summary>
        public void createSalariedEmployee()
        {
            var employee = new SalariedEmployee();
            Console.Write("SSN: ");
            employee.Ssn = Console.ReadLine();
            Console.Write("FirstName: ");
            employee.FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            employee.LastName = Console.ReadLine();
            Console.Write("BirthDate: ");
            employee.BirthDate = Console.ReadLine();
            Console.Write("Phone: ");
            employee.Phone = Console.ReadLine();
            Console.Write("Email: ");
            employee.Email = Console.ReadLine();
            Console.Write("CommissionRate: ");
            employee.CommissionRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("GrossSales: ");
            employee.GrossSales = Convert.ToDouble(Console.ReadLine());
            Console.Write("BasicSalary: ");
            employee.BasicSalary = Convert.ToDouble(Console.ReadLine());

            employees.Add(employee);
            _employeeService.AddEmployee(employee);
        }

        /// <summary>
        /// add employee was created
        /// </summary>
        /// <returns></returns>
        public List<Employee> AddEmployee()
        {
            while (true)
            {
                Console.Write("What kind of Employee you want to create?(1.Hourly employee/2.Salaried employee)");
                int choice = Validation.checkLimit(2, 1);
                switch (choice)
                {
                    case 1:
                        createHourlyEmployee();
                        break;

                    case 2:
                        createSalariedEmployee();
                        break;

                    default:
                        break;
                }
                Console.WriteLine("Do you want to continue (Y/N): ");
                if (!Validation.checkInputYN())
                {
                    break;
                }
            }
            return employees;
        }

        /// <summary>
        /// display employee
        /// </summary>
        public void DisplayEmployee()
        {
            var employees = _employeeService.GetAllEmployee();
            Console.WriteLine(employees.Count);
            DisplayDetailByType(employees);
        }

        /// <summary>
        /// display by department name
        /// </summary>
        /// <param name="departmentName"></param>
        public void DisplayEmployeesByDepartment(string departmentName)
        {
            var department = departments.Find(x => x.Name.ToLower().Trim() == departmentName.ToLower().Trim());
            DisplayDetailByType(department.Employees);
        }

        /// <summary>
        /// display by employee name
        /// </summary>
        /// <param name="employeeName"></param>
        public void DisplayEmployee(string employeeName)
        {
            var employees = _employeeService.GetAllEmployee();
            var employeeByName = employees.FindAll(x =>
                                    (x.FirstName + x.LastName).Trim().ToLower() == employeeName.Trim().ToLower());
            DisplayDetailByType(employeeByName);
        }

        /// <summary>
        /// display detail by type
        /// </summary>
        /// <param name="employees"></param>
        private void DisplayDetailByType(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee is SalariedEmployee)
                {
                    var temp = employee as SalariedEmployee;
                    Console.WriteLine($"SalariedEmployee {temp.Display()}");
                }
                if (employee is HourlyEmployee)
                {
                    var temp = employee as HourlyEmployee;
                    Console.WriteLine($"HourlyEmployee {temp.Display()}");
                }
            }
        }

        /// <summary>
        /// report number of employee in each department
        /// </summary>
        public void NumberOfEmployee()
        {
            foreach (var item in departments)
            {
                Console.WriteLine("===== Deapartment report =====");
                Console.WriteLine(String.Format("Deapartment {0} has {1} employee(s).",
                                                            item.Name, item.Employees.Count));
                Console.WriteLine("===== End =====");
            }
        }
    }
}