using System;
using System.Net;
using System.Text.Json;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Results;

namespace MVM.CabanasDream.Locacao.API.Middlewares;

public class LoggingExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            BaseResult result = new BaseResult()
            {
                HttpCode = context.Response.StatusCode,
                Message = ex.Message,
                Sucess = false,
                Result = ex.Data
            };

            string resultJson = JsonSerializer.Serialize(result);

            await context.Response.WriteAsync(resultJson);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            BaseResult result = new BaseResult()
            {
                HttpCode = context.Response.StatusCode,
                Message = ex.Message,
                Sucess = false
            };

            string resultJson = JsonSerializer.Serialize(result);

            await context.Response.WriteAsync(resultJson);
        }
    }
}

