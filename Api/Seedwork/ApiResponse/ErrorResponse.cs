using Newtonsoft.Json.Linq;
using System.Net;

namespace Api.Seedwork.ApiResponse;

public class ErrorResponse
{
    public readonly string ErrorCode;
    public readonly HttpStatusCode HttpStatusCode;
    public readonly string Message;
    public readonly JObject? Context;

    public ErrorResponse(
        string errorCode,
        HttpStatusCode httpStatusCode,
        string message,
        JObject? context = null)
    {
        ErrorCode = errorCode;
        HttpStatusCode = httpStatusCode;
        Message = message;
        Context = context;
    }

    public static ErrorResponse UnknownError(
        string message,
        string errorCodes = "UnknownError")
    {
        return new ErrorResponse(
            errorCode: errorCodes,
            httpStatusCode: HttpStatusCode.InternalServerError,
            message: message);
    }

    public static ErrorResponse NotFound(
        string message,
        string errorCodes = "NotFound")
    {
        return new ErrorResponse(
            errorCode: errorCodes,
            httpStatusCode: HttpStatusCode.NotFound,
            message: message);
    }

    public static ErrorResponse NotAuthorized(
        string message,
        string errorCodes = "NotAuthorized")
    {
        return new ErrorResponse(
            errorCode: errorCodes,
            httpStatusCode: HttpStatusCode.Unauthorized,
            message: message);
    }

    public static ErrorResponse BadRequest(
        string message,
        string errorCodes = "BadRequest")
    {
        return new ErrorResponse(
            errorCode: errorCodes,
            httpStatusCode: HttpStatusCode.BadRequest,
            message: message);
    }

    public static ErrorResponse InternalServerError(
        string message,
        string errorCodes = "InternalServerError")
    {
        return new ErrorResponse(
            errorCode: errorCodes,
            httpStatusCode: HttpStatusCode.InternalServerError,
            message: message);
    }
}