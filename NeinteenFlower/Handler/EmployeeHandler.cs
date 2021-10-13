using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class EmployeeHandler
    {
        public static List<MsEmployee> GetEmployees()
        {
            return EmployeeRepository.GetEmployees();
        }

        public static MsEmployee GetEmployeeByID(int id)
        {
            return EmployeeRepository.GetEmployeeByID(id);
        }

        public static MsEmployee GetEmployeeByEmail(string email)
        {
            return EmployeeRepository.GetEmployeeByEmail(email);
        }

        public static void InsertEmployee(string name, string email, string password, DateTime DOB, string gender, string phone, string address, int salary, string role)
        {
            MsEmployee employee = EmployeeFactory.CreateEmployee(name, email, password, DOB, gender, phone, address, salary, role);
            EmployeeRepository.InsertEmployee(employee);
        }

        public static void UpdateEmployee(int id, string name, string email, string password, DateTime DOB, string gender, string phone, string address, int salary, string role)
        {
            MsEmployee newEmployee = EmployeeFactory.CreateEmployee(name, email, password, DOB, gender, phone, address, salary, role);
            EmployeeRepository.UpdateEmployee(id, newEmployee);
        }

        public static void DeleteEmployeeByID(int id)
        {
            EmployeeRepository.DeleteEmployeeByID(id);
        }
    }
}