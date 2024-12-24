using Api.Seedwork.ApiResponse;

namespace Api.Models.Errors;

public class BusinessError
{
    public static class UnauthorizedAccess
    {
        public static string Message = "Unable to access resource due to unauthorized access.";
        public static ErrorResponse Error() => ErrorResponse.NotAuthorized(Message);
    }

    public static class ConcurrentUpdate
    {
        public static string Code = "10001";
        public static string Message = "Unable to update due to record was recently modified by others.";
        public static ErrorResponse Error() => ErrorResponse.InternalServerError(Message, Code);
    }
}
