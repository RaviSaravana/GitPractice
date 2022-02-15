using CoreWebAPI.Controllers;
using CoreWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI
{
    public class EmployeeMockData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                EmpId=1,
                EmpName="tarun",
                Empsal=20000,
                Emploc="hyd"
            },
              new Employee()
            {
                EmpId=2,
                EmpName="giri",
                Empsal=30000,
                Emploc="nel"
            },
                new Employee()
            {
                EmpId=3,
                EmpName="shayam",
                Empsal=20000,
                Emploc="gnt"
            },
                  new Employee()
            {
                EmpId=4,
                EmpName="arun",
                Empsal=30000,
                Emploc="sap"
            },
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.EmpId = employee.EmpId;
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.EmpId);
            existingEmployee.EmpName = employee.EmpName;
            return existingEmployee;
        }

        public List<Employee> GetEmployee()
        {
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            return employees.SingleOrDefault(x => x.EmpId == id);
        }
    }
}

