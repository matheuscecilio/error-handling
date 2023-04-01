using ErrorHandling.Commands;
using ErrorHandling.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateUsingResult")]
    public async Task<IActionResult> CreateUsingResult(
        [FromBody] SaveCustomerWithResultCommand request
    )
    {
        var result = await _mediator.Send(request);

        return result.ToOk("Success!");
    }

    [HttpPost("CreateUsingEither")]
    public async Task<IActionResult> CreateUsingEither(
        [FromBody] SaveCustomerWithEitherCommand request
    )
    {
        var result = await _mediator.Send(request);

        return result.ToOk("Success!");
    }
}
