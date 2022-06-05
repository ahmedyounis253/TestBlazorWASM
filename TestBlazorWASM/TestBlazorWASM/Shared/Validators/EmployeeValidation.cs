namespace TestBlazorWASM.Shared
{
    public  class EmployeeValidation:AbstractValidator<Employee>
    {

        public EmployeeValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage($"{nameof(Employee)} Name is required");
            RuleFor(e => e.Age).InclusiveBetween(18, 70).WithMessage($"{nameof(Employee)} Age Must be in Range 18~70");
            RuleFor(e=>e.Role).NotEmpty().WithMessage($"{nameof(Employee)} Role is required");
            RuleFor(e => e.Birthdate).LessThan(DateTime.Now - TimeSpan.FromDays(365 * 70));
            RuleFor(e => e.Mobile).MaximumLength(20).WithMessage($"{nameof(Employee)} Mobile Maximum Length is 20 digits");

        }
    }
}
