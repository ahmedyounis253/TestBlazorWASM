namespace TestBlazorWASM.Shared
{
    public  class StudentValidator: BaseNameValidator<Student>
    {

        public StudentValidator()
        {
            const int mobileMaxLength = 20;
            const int minAge = 18;
            const int maxAge = 30;
            RuleFor(e => e.Age).InclusiveBetween(minAge, maxAge).WithMessage($"{nameof(Employee)} Age Must be in Range {minAge}~{maxAge}");
            RuleFor(e => e.Birthdate).LessThan(DateTime.Now - TimeSpan.FromDays(365 * maxAge));
            RuleFor(e => e.Mobile).MaximumLength(mobileMaxLength).WithMessage($"{nameof(Employee)} Mobile Maximum Length is {mobileMaxLength} digits");

        }
    }
}
