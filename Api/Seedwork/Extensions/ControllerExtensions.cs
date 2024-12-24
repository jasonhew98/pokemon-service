using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Seedwork;

public static class ControllerBaseExtension
{
    public static IActionResult OkOrError<T>(this ControllerBase controller,
        Result<T, ErrorResponse> response)
    {
        return response.IsSuccess
            ? controller.Ok(response.Value)
            : Error(controller, response.Error);
    }

    public static IActionResult AcceptedOrError<T>(this ControllerBase controller,
        Result<T, ErrorResponse> response)
    {
        return response.IsSuccess
            ? controller.Accepted(response.Value)
            : Error(controller, response.Error);
    }

    private static IActionResult Error(ControllerBase controller, ErrorResponse commandErrorResponse)
    {
        return controller.StatusCode(
            (int)commandErrorResponse.HttpStatusCode,
            new
            {
                errorCode = commandErrorResponse.ErrorCode,
                message = commandErrorResponse.Message
            });
    }
}