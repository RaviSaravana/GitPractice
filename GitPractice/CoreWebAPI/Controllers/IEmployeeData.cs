using CoreWebAPI.Model;
using System.Collections.Generic;

namespace CoreWebAPI.Controllers
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployee();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
    }
}