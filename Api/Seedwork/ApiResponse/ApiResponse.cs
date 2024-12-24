using CSharpFunctionalExtensions;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Api.Seedwork.ApiResponse;

public static class ApiResponse
{
    public static Result<T, ErrorResponse> Success<T>(T value)
    {
        return Result.Success<T, ErrorResponse>(value);
    }

    public static Result<T, ErrorResponse> NotAuthorized<T>(string message, string errorCodes = "NotAuthorized")
    {
        return Result.Failure<T, ErrorResponse>(ErrorResponse.NotAuthorized(message, errorCodes));
    }

    public static Result<T, ErrorResponse> NotFound<T>(string message, string errorCodes = "NotFound")
    {
        return Result.Failure<T, ErrorResponse>(ErrorResponse.NotFound(message, errorCodes));
    }

    public static Result<T, ErrorResponse> Error<T>(ErrorResponse error)
    {
        return Result.Failure<T, ErrorResponse>(error);
    }

    public static Result<T, ErrorResponse> Error<T>(Exception ex)
    {
        var innerException = ex.InnerException;

        if (innerException == null)
            return Result.Failure<T, ErrorResponse>(ErrorResponse.UnknownError(ex.Message, ex.GetType().ToString()));

        var errorResponse = new ErrorResponse(
            errorCode: ex.GetType().ToString(),
            message: ex.Message,
            httpStatusCode: HttpStatusCode.InternalServerError,
            context: new JObject
            {
                { "innerException", innerException.GetType().ToString() },
                { "innerExceptionMessage", innerException.Message }
            });

        return Result.Failure<T, ErrorResponse>(errorResponse);
    }
}
