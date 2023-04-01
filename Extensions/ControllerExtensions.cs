using ErrorHandling.Common;
using ErrorHandling.Responses;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Extensions;

public static class ControllerExtensions
{
    public static IActionResult ToOk<TResult>(
        this Either<ErrorResult, TResult> result,
        string message
    )
    {
        return result.Match<IActionResult>(
            obj =>
            {
                var response = new DefaultResponse<TResult>(message);
                return new OkObjectResult(response);
            },
            errorResult => new BadRequestObjectResult(errorResult)
        );
    }

    public static IActionResult ToOk<TResult>(
        this Result<TResult> result,
        string message
    )
    {
        return result.Match<IActionResult>(
            obj =>
            {
                var response = new DefaultResponse<TResult>(message);
                return new OkObjectResult(response);
            }, 
            exception =>
            {
                if (exception is ErrorResultException errorResultException)
                {
                    return new BadRequestObjectResult(errorResultException);
                }

                return new StatusCodeResult(500);
        });
    }
}
