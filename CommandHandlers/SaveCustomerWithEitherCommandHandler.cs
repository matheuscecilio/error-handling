using ErrorHandling.Commands;
using ErrorHandling.Common;
using ErrorHandling.Requests;
using FluentValidation;
using LanguageExt;
using MediatR;

namespace ErrorHandling.CommandHandlers;

public class SaveCustomerWithEitherCommandHandler
    : IRequestHandler<SaveCustomerWithEitherCommand, Either<ErrorResult, bool>>
{
    private readonly IValidator<SaveCustomerRequest> _validator;

    public SaveCustomerWithEitherCommandHandler(IValidator<SaveCustomerRequest> validator)
    {
        _validator = validator;
    }

    public async Task<Either<ErrorResult, bool>> Handle(
        SaveCustomerWithEitherCommand request, 
        CancellationToken cancellationToken
    )
    {
        var validatorResult = await _validator.ValidateAsync(
            request,
            cancellationToken
        );

        if (!validatorResult.IsValid)
        {
            var errorResult = new ErrorResult(validatorResult.Errors);

            return errorResult;
        }

        return true;
    }
}
