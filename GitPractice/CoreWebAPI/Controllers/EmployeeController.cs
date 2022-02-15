using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebAPI.Model;


namespace CoreWebAPI.Controllers
{

    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployee()
        {
            return Ok(_employeeData.GetEmployee());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"employe Id{id} was not found");

        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.EmpId, employee);

        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok(employee);
            }
            return NotFound($"employe Id{id} was not found");

        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(int id, Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);
            if (existingEmployee != null)
            {
                employee.EmpId = existingEmployee.EmpId;
                _employeeData.EditEmployee(employee);
            }
            return Ok(employee);

        }
    }
}
