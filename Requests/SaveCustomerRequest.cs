namespace ErrorHandling.Requests;

public class SaveCustomerRequest
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
}