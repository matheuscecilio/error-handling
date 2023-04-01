using ErrorHandling.Requests;
using LanguageExt.Common;
using MediatR;

namespace ErrorHandling.Commands;

public class SaveCustomerWithResultCommand
    : SaveCustomerRequest, IRequest<Result<bool>> { }
