using FluentValidation;

namespace EmployeeService.Models.Validators
{
    public class DepartmentDtoValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

           RuleFor (x => x.Description)
                .NotNull()
                .NotEmpty()
                .Length(1, 128);
        }
    }
}
