namespace MassUprising24.API.Model;

public class ApiResponse<T>
{
    public ApiResponse(bool success, string message, T? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
}
