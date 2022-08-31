using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        public int Create(EmployeeType data)
        {
            return 3;
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
           // throw new NotImplementedException();
        }

        public IList<EmployeeType> GetAll()
        {
            return new List<EmployeeType>();
            //throw new NotImplementedException();
        }

        public EmployeeType GetById(int id)
        {
            return new EmployeeType();
            //throw new NotImplementedException();
        }

        public void Update(EmployeeType data)
        {
            //throw new NotImplementedException();
        }
    }
}
