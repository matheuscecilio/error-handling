using ErrorHandling.Common;
using ErrorHandling.Requests;
using LanguageExt;
using MediatR;

namespace ErrorHandling.Commands;

public class SaveCustomerWithEitherCommand 
    : SaveCustomerRequest, IRequest<Either<ErrorResult, bool>> { }
