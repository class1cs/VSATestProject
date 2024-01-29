namespace VSATestProject.Dtos;

public class BaseResponse
{
    public BaseResponse(string message, string[] errors)
    {
        Message = message;
        Errors = errors;
    }

    public string Message { get; set; }
    
    public string[] Errors { get; set; }
}

public class BaseResponse<T>
{
    public string Message { get; set; }
    
    public string[] Errors { get; set; }
    
    public T Data { get; set; }

    public BaseResponse(string message, T data, string[] errors)
    {
        Message = message;
        Errors = errors;
        Data = data;

    }
}