namespace ErrorHandling.Responses;

public record DefaultResponse<TResponse>
{
    public string Message { get; init; }
    public IEnumerable<TResponse>? Data { get; init; }

    public DefaultResponse(string message) 
        => Message = message;

    public DefaultResponse(
        string message, 
        IEnumerable<TResponse> data
    )
    {
        Message = message;
        Data = data;
    }
}
