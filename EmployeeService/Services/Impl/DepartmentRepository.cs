using EmployeeService.Data;

namespace EmployeeService.Services.Impl
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public int Create(Department data)
        {
            return 2;
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            return;
        }

        public IList<Department> GetAll()
        {
            return new List<Department>();
            //throw new NotImplementedException();
        }

        public Department GetById(int id)
        {
            return new Department();
            //throw new NotImplementedException();
        }

        public void Update(Department data)
        {
            // throw new NotImplementedException();
            return;
        }
    }
}
