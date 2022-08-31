using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using EmployeeService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;
        private readonly ILogger<DictionariesController> _logger;

        public DictionariesController(
            IEmployeeTypeRepository employeeTypeRepository,
            ILogger<DictionariesController> logger)
        {
            _employeeTypeRepository = employeeTypeRepository;
            _logger = logger;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateDictionaryRequest request)
        {
            _logger.LogInformation($"Create employee type.");

            return Ok(_employeeTypeRepository.Create(new EmployeeType
            {
                Description = request.Description,
            }));
        }

            [HttpGet("employee-types/all")]

            public ActionResult<List<EmployeeTypeDto>> GetAllEmployeeTypes()
        {
                _logger.LogInformation($"Employeee GetAllEmployeeTypes.");
                return Ok(_employeeTypeRepository.GetAll().Select(employee => new EmployeeTypeDto
                {
                    Description = employee.Description,
                }
                ).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<EmployeeTypeDto> GetById([FromRoute] int id)
        {
            _logger.LogInformation($"Employee type GetById({id}).");
            var employeeType = _employeeTypeRepository.GetById(id);
            return Ok(new EmployeeTypeDto
            {
                Id = employeeType.Id,
                Description = employeeType.Description
            });
        }

        [HttpGet("update")]
        public ActionResult<EmployeeTypeDto> Update([FromBody] EmployeeType employeeType)
        {
            _logger.LogInformation($"Employee type Update({employeeType.Id}).");
            _employeeTypeRepository.Update(employeeType);
            return Ok();
        }

        [HttpGet("delete/{id}")]
        public ActionResult<EmployeeTypeDto> Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Employee type Delete({id}).");
            _employeeTypeRepository.Delete(id);
            return Ok();
        }
    }
}
