using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class EmployeeController
    {
        public static string InsertEmployee(string name, string email, string password, DateTime DOB, string gender, string address, string phone, string salary, string role)
        {
            string message = "";

            message = ValidateEmployeeData(name, email, password, DOB, gender, phone, address, salary, role);

            if (message.Equals("")) EmployeeHandler.InsertEmployee(name, email, password, DOB, gender, phone, address, Int32.Parse(salary), role);

            return message;
        }

        public static string UpdateEmployee(int id, string name, string email, string password, DateTime DOB, string gender, string address, string phone, string salary, string role)
        {
            string message = "";

            message = ValidateEmployeeData(name, email, password, DOB, gender, phone, address, salary, role);

            if (message.Equals("")) EmployeeHandler.UpdateEmployee(id, name, email, password, DOB, gender, address, phone, Int32.Parse(salary), role);

            return message;
        }

        private static string ValidateEmployeeData(string name, string email, string password, DateTime DOB, string gender, string phone, string address, string salary, string role)
        {
            return ValidateName(name) + ValidateEmail(email, role) + ValidatePassword(password) + ValidateAge(DOB) + ValidateGender(gender) + ValidatePhone(phone) + ValidateAddress(address) + ValidateSalary(salary) + ValidateRole(role);
        }

        private static string ValidateName(string name)
        {
            if (!name.All(Char.IsLetter)) return "Name field must only be filled with letter!<br/ >";
            if (name.Length < 3) return "Name minimal length is 3 characters!<br/ >";
            if (name.Length > 20) return "Name maximal length is 3 characters!<br/ >";
            return "";
        }

        private static string ValidateEmail(string email, string role)
        {
            if (email.Equals("")) return "Email field is required!<br/ >";
            MsEmployee employeeExist = EmployeeHandler.GetEmployeeByEmail(email);

            if (employeeExist != null) return "Email is taken! It must be unique<br/ >";
            if (role.Equals("Admin") && !email.EndsWith("@admin.com")) return "Email must be ending with @admin.com!<br/ >";
            else if (role.Equals("Employee") && !email.EndsWith("@employee.com")) return "Email must be ending with @employee.com!<br/ >";
            else if (!email.EndsWith("@admin.com") && !email.EndsWith("@employee.com")) return "Email must be ending with @admin.com or @employee.com!<br/ >";
            return "";
        }

        private static string ValidatePassword(string password)
        {
            if (password.Length < 3) return "Password minimal length is 3 characters!<br/ >";
            if (password.Length > 20) return "Password maximal length is 3 characters!<br/ >";
            return "";
        }

        private static string ValidateAge(DateTime DOB)
        {
            try
            {
                DateTime now = DateTime.Now;

                int age = now.Year - DOB.Year;
                if (now.Month > DOB.Month || (now.Month == DOB.Month && now.Day < DOB.Day)) --age;

                return age < 17 ? "Minimum age for employee is 17 years old!<br/ >" : "";
            }
            catch (Exception)
            {
                return "Date of Birth is not a valid date!<br/ >";
            }
        }

        private static string ValidateGender(string gender)
        {
            if (gender.Length == 0) return "Gender must be choosen!<br/ >";
            return "";
        }

        private static string ValidatePhone(string phone)
        {
            if (!phone.All(Char.IsDigit)) return "Phone Number must be numeric!<br/ >";
            return "";
        }

        private static string ValidateAddress(string address)
        {
            if (!address.Contains("Street")) return "Address must contain the word \"Street\"!<br/ >";
            return "";
        }

        private static string ValidateSalary(string salary)
        {
            int intSalary = 0;
            if (!int.TryParse(salary, out intSalary)) return "Salary must be numeric!<br/ >";
            return intSalary < 100 || intSalary > 1000 ? "Salary value must be between 100 to 1000 inclusively!<br/ >" : "";
        }

        private static string ValidateRole(string role)
        {
            return !role.Equals("Admin") && !role.Equals("Employee") ? "Role must be between Admin or Employee!<br/ >" : "";
        }
    }
}