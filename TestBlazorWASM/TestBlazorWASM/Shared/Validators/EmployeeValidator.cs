namespace TestBlazorWASM.Shared
{
    public  class EmployeeValidator:BaseNameValidator<Employee>
    {

        public EmployeeValidator()
        {
            const int mobileMaxLength = 20;
            const int minAge = 18;
            const int maxAge = 70;
            RuleFor(e => e.Age).InclusiveBetween(minAge, maxAge).WithMessage($"{nameof(Employee)} Age Must be in Range {minAge}~{maxAge}");
            RuleFor(e=>e.Role).NotEmpty().WithMessage($"{nameof(Employee)} Role is required");
            RuleFor(e => e.Birthdate).LessThan(DateTime.Now - TimeSpan.FromDays(365 * maxAge));
            RuleFor(e => e.Mobile).MaximumLength(mobileMaxLength).WithMessage($"{nameof(Employee)} Mobile Maximum Length is {mobileMaxLength} digits");

        }
    }
}
