namespace TestBlazorWASM.Shared
{
    public  class BaseNameValidator<TEntitiy> : AbstractValidator<TEntitiy> 
        where TEntitiy : BaseNameEntity
    {
        public BaseNameValidator()
        {


            const int nameMaxLength = 20;
            RuleFor(e => e.Name).NotEmpty().WithMessage($"{nameof(Employee)} Name is required");
            RuleFor(e => e.Name).MaximumLength(nameMaxLength).WithMessage($"{nameof(Employee)} Name max length={nameMaxLength}");
        }

    }
}
