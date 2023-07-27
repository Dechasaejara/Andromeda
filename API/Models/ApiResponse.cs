namespace Andromenda.API.Models;
public class ApiSuccessResponse
{
    public bool? Success { get; set; } = true;
    public int? StatusCode { get; set; } = 200;
    public string? Message { get; set; } = "Success";
    public Object? Data { get; set; } = null;

}
public class ApiErrorResponse
{
    public bool? Success { get; set; } = false;
    public int? StatusCode { get; set; } = 400;
    public string? Message { get; set; } = "Fail";
    public Object? Data { get; set; } = null;

}