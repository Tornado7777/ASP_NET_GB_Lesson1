using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using EmployeeService.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Authorize]
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

        [HttpPost("employee-types/create")]
        public ActionResult<int> Create([FromBody] CreateDictionaryRequest request)
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
                return Ok(_employeeTypeRepository.GetAll().Select(employeeType => new EmployeeTypeDto
                {
                    Id = employeeType.Id,
                    Description = employeeType.Description,
                }
                ).ToList());
        }

        [HttpGet("employee-types/get/{id}")]
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

        [HttpPost ("employee-types/update")]
        public ActionResult<EmployeeTypeDto> Update([FromBody] EmployeeTypeDto employeeTypeDto)
        {
            _logger.LogInformation($"Employee type Update({employeeTypeDto.Id}).");
            _employeeTypeRepository.Update(new EmployeeType
            {
                Id = employeeTypeDto.Id,
                Description=employeeTypeDto.Description
            });
            return Ok();
        }

        [HttpDelete ("employee-types/delete/{id}")]
        public ActionResult<EmployeeTypeDto> Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Employee type Delete({id}).");
            _employeeTypeRepository.Delete(id);
            return Ok();
        }
    }
}
