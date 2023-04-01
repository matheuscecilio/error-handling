using ErrorHandling.Requests;
using FluentValidation;

namespace ErrorHandling.Validators;

public class SaveCustomerRequestValidator : AbstractValidator<SaveCustomerRequest>
{
    public SaveCustomerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Surname)
            .NotNull()
            .NotEmpty()
            .WithMessage("Surname is required");

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("E-mail is required");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid e-mail");
    }
}
