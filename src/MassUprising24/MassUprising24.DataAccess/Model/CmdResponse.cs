namespace MassUprising24.Domain.Model;

public class CmdResponse
{
    //public CmdResponse(int id, string message, bool success)
    //{
    //    Id = id;
    //    Message = message;
    //    Success = success;
    //}

    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }
}
