using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Dtos;
using VSATestProject.Services;

namespace VSATestProject.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context, ApplicationContext applicationContext, TokenCheck.TokenCheckHandler tokenCheckHandler)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
        await tokenCheckHandler.HandleAsync(context, token, applicationContext);
        await _next(context);
    }
    
    
}

