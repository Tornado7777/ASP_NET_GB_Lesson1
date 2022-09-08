using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Services

        private readonly EmployeeServiceDbContext _context;

        #endregion

        #region Constructor

        public EmployeeRepository(EmployeeServiceDbContext context)
        {
            _context = context;
        }
        #endregion
        public int Create(Employee data)
        {
            _context.Employees.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public void Delete(int id)
        {
            Employee employee = GetById(id);
            if (employee == null)
                throw new Exception("Employee not found.");
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public IList<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee data)
        {
            if (data == null) throw new ArgumentNullException("data is null");
            Employee employee = GetById(data.Id);
            employee.Department = data.Department;
            employee.FirstName = data.FirstName;
            employee.Surname = data.Surname;
            employee.Patronymic = data.Patronymic;
            employee.Salary = data.Salary;
            _context.SaveChanges();
        }
    }
}
