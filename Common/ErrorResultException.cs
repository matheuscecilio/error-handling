using FluentValidation.Results;

namespace ErrorHandling.Common;

public record ErrorResultItemException(
    string Context,
    string Message
);

public class ErrorResultException : Exception // Can't be record
{
    public ErrorResultItemException[] Errors { get; set; }

    public ErrorResultException(IEnumerable<ValidationFailure> validationFailures)
    {
        Errors = validationFailures
            .Select(x => new ErrorResultItemException(x.PropertyName, x.ErrorMessage))
            .ToArray();
    }
}
