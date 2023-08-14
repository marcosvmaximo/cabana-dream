using System.Net;
using System.Text.Json;
using MVM.CabanasDream.Core.Domain.Exceptions;

namespace MVM.CabanasDream.API.Middlewares;

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

            var errorDetails = new
            {
                type = "DOMAIN_EXCEPTION",
                message = ex.Message,
                details = ex.Data // Informações adicionais, se disponíveis
            };

            var result = new
            {
                httpStatusCode = context.Response.StatusCode,
                sucess = false,
                message = "Ocorreu um erro inesperado ao realizar esta operação.",
                data = errorDetails
            };

            string resultJson = JsonSerializer.Serialize(result);

            await context.Response.WriteAsync(resultJson);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var result = new
            {
                httpStatusCode = context.Response.StatusCode,
                sucess = false,
                message = "Ocorreu um erro de serviço inesperado ao realizar esta operação, tente novamente mais tarde.",
                data = new
                {
                    type = "SERVER_EXCEPTION",
                    message = ex.Message,
                    details = ex.Data // Informações adicionais, se disponíveis
                }
            };

            string resultJson = JsonSerializer.Serialize(result);

            await context.Response.WriteAsync(resultJson);
        }
    }
}

