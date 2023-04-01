using ErrorHandling.Commands;
using ErrorHandling.Common;
using ErrorHandling.Requests;
using FluentValidation;
using LanguageExt.Common;
using MediatR;

namespace ErrorHandling.CommandHandlers;

public class SaveCustomerWithResultCommandHandler
    : IRequestHandler<SaveCustomerWithResultCommand, Result<bool>>
{
    private readonly IValidator<SaveCustomerRequest> _validator;

    public SaveCustomerWithResultCommandHandler(IValidator<SaveCustomerRequest> validator)
    {
        _validator = validator;
    }

    public async Task<Result<bool>> Handle(
        SaveCustomerWithResultCommand request, 
        CancellationToken cancellationToken
    )
    {
        var validatorResult = await _validator.ValidateAsync(
            request,
            cancellationToken
        );

        if (!validatorResult.IsValid)
        {
            var errorResultException = new ErrorResultException(validatorResult.Errors);

            return new Result<bool>(errorResultException);
        }

        return new Result<bool>(true);
    }
}
