using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Net.M.A010.Models
{
    public static class Validation
    {
        /// <summary>
        /// this is extension method for String class.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>return true if date is dd/MMM/yyyy format, otherwise:false</returns>
        public static bool IsBirtDate(this string date)
        {
            bool isDate = DateTime.TryParseExact(date,
                                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                    DateTimeStyles.None, out DateTime result);
            return isDate;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(this string phone)
        {
            bool isPhone = phone.All(char.IsDigit);
            return isPhone && phone.Length >= 7;
        }

        /// <summary>
        /// check email format
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(this string email)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var regex = new Regex(pattern);
            bool isEmail = regex.IsMatch(email);
            return isEmail;
        }


        /// <summary>
        /// check string only alphabet
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsAllAlphabetic(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// check input string
        /// </summary>
        /// <returns></returns>
        public static String checkInputString()
        {
            //loop until user input correct
            while (true)
            {
                String result = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(result) || !IsAllAlphabetic(result))
                {
                    Console.WriteLine("Empty or Wrong");
                    Console.WriteLine("Enter again: ");
                }
                else
                {
                    return result;
                }
            }
        }

        /// <summary>
        /// check input option
        /// </summary>
        /// <returns></returns>
        public static Boolean checkInputYN()
        {
            //loop until user input correct
            while (true)
            {
                String result = checkInputString();
                //check user input y/Y or n/N
                if (String.Equals(result, "Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
                else if (String.Equals(result, "N", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                Console.WriteLine("Please input y/Y or n/N.");
                Console.WriteLine("Enter again: ");
            }
        }

        /// <summary>
        /// Config optiion
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static int checkLimit(int max, int min)
        {
            while (true)
            {
                try
                {
                    int result = int.Parse(Console.ReadLine().Trim());
                    if (result < min || result > max)
                    {
                        throw new FormatException();
                    }
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input number in rage [" + min + ", " + max + "]");
                    Console.WriteLine("Enter again: ");
                }
            }
        }
    }
}