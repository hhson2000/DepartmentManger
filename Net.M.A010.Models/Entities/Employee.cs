using System;

namespace Net.M.A010.Models.Entities
{
    public abstract class Employee
    {
        private string _birthDate;
        private string _phone;
        private string _email;

        public string Ssn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate
        {
            get => _birthDate;
            set
            {
                if (value.IsBirtDate())
                    _birthDate = value;
                else
                    throw new Exception($"{value} is incorrect following format dd/MM/yyyy");
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (value.IsPhoneNumber())
                    _phone = value;
                else
                    throw new Exception("Number phone must minimum 7 positive integers!");
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value.IsEmail())
                    _email = value;
                else
                    throw new Exception("Email is incorrect!");
            }
        }

        public abstract string Display();

        public override string ToString()
        {
            return String.Format("Info[SSN: = {0} - Name: {1} {2} - Email: {3} - Phone: {4}]",
                                             Ssn, FirstName, LastName, Email, Phone); ;
        }
    }
}