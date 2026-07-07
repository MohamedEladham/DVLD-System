using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Shared.Global_Classes
{
    public class clsValidationHelper
    {
        // Enter Noly Number
        //if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; // امنع الإدخال


        public static bool IsMatchingPersonID(int personID, string outValue)
        {
            if (int.TryParse(outValue, out int id))
                return personID == id;

            return false;
        }

        public static bool ContainsIgnoreCase(string source, string value)
        {
            return !string.IsNullOrEmpty(source) && source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }


        // >>

        public static DateTime GetToDayDate()
        {
            return DateTime.Today;
        }

        public static bool IsAdult(DateTime dateOfBirth)
        {
            const int minimumAge = 18;
            return dateOfBirth <= DateTime.Today.AddYears(-minimumAge);
        }

        public static bool IsValidAgeRange(DateTime dateOfBirth, int minAge, int maxAge)
        {
            return dateOfBirth <= DateTime.Today.AddYears(-minAge) && dateOfBirth >= DateTime.Today.AddYears(-maxAge);
        }

        public static bool IsValidAgeRange2(DateTime dateOfBirth)
        {
            const int minimumAge = 18;
            const int maximumAge = 120;

            if (dateOfBirth > DateTime.Today)
                return false;

            DateTime today = DateTime.Today;

            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
                age--;

            return age >= minimumAge && age <= maximumAge;
        }

        public static DateTime GetLatestBirthDateForAge(int minimumAge)
        {
            return DateTime.Today.AddYears(-minimumAge);
        }

        public static bool IsValidLength(string value, int from, int to)
        {
            return value.Length >= from && value.Length <= to;
        }

        public static bool IsNumberBetween(int value, int from, int to)
        {
            return value >= from && value <= to;
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsAlphaNumeric(string input)
        {
            // يسمح فقط بالحروف الإنجليزية والأرقام
            return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
        }

        public static bool IsValidInputWithSpace(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9 ]+$");
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(01\d{9}|\+201\d{9})$";

            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsValidPhoneNumber2(string phone)
        {
            string pattern = @"^\+?\d{11,12}$";

            if (!Regex.IsMatch(phone, pattern))
                return false;

            if (!(phone.StartsWith("01") || phone.StartsWith("+01")))
                return false;

            return true;
        }

       
    }
}
