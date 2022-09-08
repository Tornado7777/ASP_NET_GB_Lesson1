using Grpc.Core;
using DepartmentServiceProto;
using static DepartmentServiceProto.DepartmentService;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class DepartmentService : DepartmentServiceBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public override Task<CreateDepartmentResponse> CreateDepartment(CreateDepartmentRequest createDepartmentRequest, ServerCallContext context)
        {

            var id = _departmentRepository.Create(new Data.Department
            {
                Description = createDepartmentRequest.Description,
            });
            CreateDepartmentResponse response = new CreateDepartmentResponse();
            response.Id = id;
            return Task.FromResult(response);

        }


        public override Task<GetAllDepartmentsResponse> GetAllDepartments(GetAllDepartmentsRequest request, ServerCallContext context)
        {
            GetAllDepartmentsResponse response = new GetAllDepartmentsResponse();
            response.Departments.AddRange(_departmentRepository.GetAll().Select(et =>
            new DepartmentServiceProto.Department
            {
                Id = et.Id,
                Description = et.Description,
            }).ToList());
            return Task.FromResult(response);
        }

        public override Task<GetByIdDepartmentResponse> GetByIdDepartment(GetByIdDepartmentRequest request, ServerCallContext context)
        {
            var department = _departmentRepository.GetById(request.Id);
            GetByIdDepartmentResponse response = new GetByIdDepartmentResponse();
            response.Id = department.Id;
            response.Description = department.Description;
           
            return Task.FromResult(response);
        }

        public override Task<UpdateDepartmentResponse> UpdateDepartment(UpdateDepartmentRequest request, ServerCallContext context)
        {
            _departmentRepository.Update(new Data.Department
            {
                Id=request.Id,
                Description=request.Description,   
            });
            

            return Task.FromResult(new UpdateDepartmentResponse());
        }

        public override Task<DeleteDepartmentResponse> DeleteDepartment(DeleteDepartmentRequest request, ServerCallContext context)
        {
            _departmentRepository.Delete(request.Id);
            return Task.FromResult(new DeleteDepartmentResponse());
        }
    }
}
