using FluentValidation.Results;

namespace ErrorHandling.Common;

public record ErrorResultItem(
    string Context,
    string Message
);

public record ErrorResult
{
    public ErrorResultItem[] Errors { get; set; }

    public ErrorResult(IEnumerable<ValidationFailure> validationFailures)
    {
        Errors = validationFailures
            .Select(x => new ErrorResultItem(x.PropertyName, x.ErrorMessage))
            .ToArray();
    }
}
