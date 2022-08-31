using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using EmployeeService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Services

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;

        #endregion

        public EmployeeController(
            IEmployeeRepository employeeRepository,
            ILogger<EmployeeController> logger
            )
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateEmployeeRequest request)
        {
            _logger.LogInformation($"Create employee.");

            return Ok(_employeeRepository.Create(new Employee
            {
                DepartmentId = request.DepartmentId,
                EmployeeTypeId = request.EmployeeTypeId,
                FirstName = request.FirstName,
                Patronymic = request.Patronymic,
                Salary = request.Salary,
                Surname = request.Surname
            }));
        }

        [HttpGet("get/all")]
        public ActionResult<List<EmployeeDto>> GetAllEmployees()
        {
            _logger.LogInformation($"Employeee GetAllEmployees.");
            return Ok(_employeeRepository.GetAll().Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                Salary = employee.Salary,
                Patronymic = employee.Patronymic,
                Surname = employee.Surname
            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<EmployeeDto> GetById([FromRoute] int id)
        {
            _logger.LogInformation($"Employee GetById({id}).");
            var employee = _employeeRepository.GetById(id);
            return Ok(new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                Salary = employee.Salary,
                Patronymic = employee.Patronymic,
                Surname = employee.Surname
            });
        }

        [HttpGet("update")]
        public ActionResult<EmployeeDto> Update([FromBody] Employee employee)
        {
            _logger.LogInformation($"Employee Update({employee.Id}).");
            _employeeRepository.Update(employee);
            return Ok();
        }

        [HttpGet("delete/{id}")]
        public ActionResult<EmployeeDto> Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Employee Delete({id}).");
            _employeeRepository.Delete(id);
            return Ok();
        }

    }
}
