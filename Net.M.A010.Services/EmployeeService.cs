using Net.M.A010.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net.M.A010.Services
{
    public class EmployeeService
    {
        private static List<Employee> _employees;
        public EmployeeService()
        {
            _employees = new List<Employee>()
            {
                new HourlyEmployee()
                {
                    Ssn="1",
                    FirstName="Nguyen Van",
                    LastName="A",
                    Email="email@gmail.com",
                    Phone="123456789",
                    BirthDate="12/12/2020",
                    Wage=4,
                    WorkingHours=60
                },
                 new SalariedEmployee()
                {
                    Ssn="2",
                    FirstName="Nguyen Van",
                    LastName="A",
                    Email="email@gmail.com",
                    Phone="123456789",
                    BirthDate="12/12/2020",
                    CommissionRate=4,
                    GrossSales=4,
                    BasicSalary=100
                }
            };
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            
        }

        public bool Delete(string ssn)
        {
            var employee = _employees.Find(x => x.Ssn == ssn);
            _employees.Remove(employee);
            return true;
        }

        public List<Employee> FindByCondition(Func<Employee,bool> predicate)
        {
            return _employees.Where(predicate).ToList();
        }

        public List<Employee> GetAllEmployee()
        {
            return _employees;
        }
    }
}