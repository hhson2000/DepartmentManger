using System;

namespace Net.M.A010.Models.Entities
{
    public class SalariedEmployee : Employee
    {
        //auto-implemented property
        public double CommissionRate { get; set; }

        public double GrossSales { get; set; }

        public double BasicSalary { get; set; }

        public override string Display() => String.Format("[SSN: = {0} - Name: {1} {2} - Email: {3} - Phone: {4}]",
                                             Ssn, FirstName, LastName, Email, Phone);
    }
}