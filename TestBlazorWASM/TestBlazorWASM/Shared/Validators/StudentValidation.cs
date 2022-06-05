namespace TestBlazorWASM.Shared
{
    public  class StudentValidation:AbstractValidator<Student>
    {

        public StudentValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage($"{nameof(Student)} Name is required");
            RuleFor(e => e.Age).InclusiveBetween(18, 70).WithMessage($"{nameof(Student)} Age Must be in Range 18~70");
            RuleFor(e => e.Birthdate).LessThan(DateTime.Now - TimeSpan.FromDays(365 * 70));
            RuleFor(e => e.Mobile).MaximumLength(20).WithMessage($"{nameof(Student)} Mobile Maximum Length is 20 digits");

        }
    }
}
