using System;
using System.Net;

namespace MVM.CabanasDream.Core.Domain.Models;

public class BaseResult
{
    public BaseResult()
    {
    }

    public BaseResult(int httpCode, string message, bool sucess, object? result)
    {
        HttpCode = httpCode;
        Message = message;
        Sucess = sucess;
        Result = result;
    }

    public int HttpCode { get; set; }
    public string Message { get; set; }
    public bool Sucess { get; set; }
    public object? Result { get; set; }

    public static BaseResult BadResult(object? result = null)
    {
        return new BaseResult()
        {
            HttpCode = (int)HttpStatusCode.BadRequest,
            Message = "Ocorreu um erro ao realizar essa operação.",
            Sucess = false,
            Result = result
        };
    }

    public static BaseResult OkResult(object? result)
    {
        return new BaseResult()
        {
            HttpCode = (int)HttpStatusCode.OK,
            Message = "Operação realizada com sucesso",
            Sucess = true,
            Result = result
        };
    }
}

