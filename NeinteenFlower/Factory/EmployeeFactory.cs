using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class EmployeeFactory
    {
        public static MsEmployee CreateEmployee(string name, string email, string password, DateTime DOB, string gender, string phone, string address, int salary, string role)
        {
            MsEmployee employee = new MsEmployee();
            employee.EmployeeName = name;
            employee.EmployeeEmail = email;
            employee.EmployeePassword = password;
            employee.EmployeeDOB = DOB.Date;
            employee.EmployeeGender = gender;
            employee.EmployeePhone = phone;
            employee.EmployeeAddress = address;
            employee.EmployeeSalary = salary;
            employee.EmployeeRole = role;
            return employee;
        }
    }
}