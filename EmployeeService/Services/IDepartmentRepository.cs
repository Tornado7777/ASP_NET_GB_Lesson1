using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services
{
    public interface IDepartmentRepository : IRepository<Department, int> { }
}
