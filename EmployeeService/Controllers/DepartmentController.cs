using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Options;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using EmployeeService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        #region Services

        private readonly ILogger<DepartmentController> _logger;
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IDepartmentRepository _departmentRepository;

        #endregion

        #region Constructors

        public DepartmentController(
            ILogger<DepartmentController> logger,
            IOptions<LoggerOptions> loggerOptions,
            IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _loggerOptions = loggerOptions;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateDepartmentRequest request)
        {
            _logger.LogInformation($"Create department.");
            return Ok(_departmentRepository.Create(new Department
            {
                description = request.Description
            }
            ));
        }

        [HttpGet("all")]
        public ActionResult<List<DepartmentDto>> GetAllDepartments()
        {
            _logger.LogInformation("Department GetAllDepartments.");

            return Ok(_departmentRepository.GetAll().Select(department => new DepartmentDto
            {
                Id = department.Id,
                Description = department.description
            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<DepartmentDto> GetById([FromRoute] int id)
        {
            _logger.LogInformation($"Department GetById({id}).");
            var department = _departmentRepository.GetById(id);
            return Ok(new DepartmentDto
            {
                Id = department.Id,
                Description = department.description
            });
        }

        [HttpGet("update")]
        public ActionResult<DepartmentDto> Update([FromBody] Department department)
        {
            _logger.LogInformation($"Department Update({department.Id}).");
            _departmentRepository.Update(department);
            return Ok();
        }

        [HttpGet("delete/{id}")]
        public ActionResult<DepartmentDto> Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Department Delete({id}).");
            _departmentRepository.Delete(id);
            return Ok();
        }

        #endregion

    }
}
