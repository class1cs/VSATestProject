using VSATestProject.Dtos;
using VSATestProject.Exceptions;

namespace VSATestProject.Middlewares;

public class HandleExceptionsMiddleware
{
    private readonly RequestDelegate _next;

    public HandleExceptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomException e)
        {
            context.Response.StatusCode = e.StatusCode;
            await context.Response.WriteAsJsonAsync(new BaseResponse(e.Message, e.Errors.ToArray()));
        }
    }
}