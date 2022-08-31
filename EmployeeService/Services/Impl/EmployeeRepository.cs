using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public int Create(Employee data)
        {
            return 1;
           // throw new NotImplementedException();
        }

        public void Delete(int id)
        {
          //  throw new NotImplementedException();
        }

        public IList<Employee> GetAll()
        {
            return new List<Employee>();
          //  throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            return new Employee();
            //  throw new NotImplementedException();
        }

        public void Update(Employee data)
        {
          //  throw new NotImplementedException();
        }
    }
}
