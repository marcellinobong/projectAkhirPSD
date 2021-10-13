using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class EmployeeRepository
    {
        public static List<MsEmployee> GetEmployees()
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return db.MsEmployees.ToList();
        }

        public static MsEmployee GetEmployeeByID(int id)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return db.MsEmployees.Find(id);
        }

        public static MsEmployee GetEmployeeByEmail(string email)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return db.MsEmployees.FirstOrDefault(e => e.EmployeeEmail.Equals(email));
        }

        public static void InsertEmployee(MsEmployee employee)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            db.MsEmployees.Add(employee);
            db.SaveChanges();
        }

        public static void UpdateEmployee(int id, MsEmployee newEmployee)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            MsEmployee employee = GetEmployeeByID(id);
            employee.EmployeeName = newEmployee.EmployeeName;
            employee.EmployeeEmail = newEmployee.EmployeeEmail;
            employee.EmployeePassword = newEmployee.EmployeePassword;
            employee.EmployeeDOB = newEmployee.EmployeeDOB;
            employee.EmployeeGender = newEmployee.EmployeeGender;
            employee.EmployeePhone = newEmployee.EmployeePhone;
            employee.EmployeeAddress = newEmployee.EmployeeAddress;
            employee.EmployeeSalary = newEmployee.EmployeeSalary;
            employee.EmployeeRole = newEmployee.EmployeeRole;

            db.SaveChanges();
        }

        public static void DeleteEmployeeByID(int id)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            MsEmployee employee = GetEmployeeByID(id);
            db.MsEmployees.Remove(employee);

            db.SaveChanges();
        }
    }
}