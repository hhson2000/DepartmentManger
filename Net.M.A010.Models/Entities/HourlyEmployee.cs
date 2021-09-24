using System;

namespace Net.M.A010.Models.Entities
{
    public class HourlyEmployee : Employee
    {
        public double Wage { get; set; }

        public double WorkingHours { get; set; }

        public override string Display() => String.Format("  [SSN: = {0} - Name: {1} {2} - Email: {3} - Phone: {4}]",
                                             Ssn, FirstName, LastName, Email, Phone);
    }
}