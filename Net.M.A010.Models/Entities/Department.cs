using System.Collections.Generic;

namespace Net.M.A010.Models.Entities
{
    public class Department
    {
        public Department()
        {
            this.Employees = new List<Employee>();
        }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

        public void Display()
        {
        }
    }
}