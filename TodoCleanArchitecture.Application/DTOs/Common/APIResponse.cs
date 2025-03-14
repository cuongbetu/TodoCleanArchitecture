using System.Net;
using System.Runtime.Serialization;

namespace TodoCleanArchitecture.Application.DTOs.Common;

[DataContract]
public class APIResponse
{
    [DataMember]
    public int StatusCode { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string Message { get; set; }

    [DataMember(EmitDefaultValue = true)]
    public object Result { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string ErrorCode { get; set; }

    public APIResponse(
        int statusCode,
        object result = default,
        string message = "",
        string errorCode = "")
    {
        StatusCode = statusCode;
        Result = result;
        Message = message;
        ErrorCode = errorCode;
    }

    // Factory Methods for common response types
    public static APIResponse BadRequest(string message = "Bad Request", string errorCode = "400")
    {
        return new APIResponse((int)HttpStatusCode.BadRequest, null, message, errorCode);
    }

    public static APIResponse Unauthorized(string message = "Unauthorized", string errorCode = "401")
    {
        return new APIResponse((int)HttpStatusCode.Unauthorized, null, message, errorCode);
    }

    public static APIResponse NotFound(string message = "Not Found", string errorCode = "404")
    {
        return new APIResponse((int)HttpStatusCode.NotFound, null, message, errorCode);
    }

    public static APIResponse Success(object result, string message = "Success")
    {
        return new APIResponse((int)HttpStatusCode.OK, result, message);
    }

    public static APIResponse Exception(Exception ex)
    {
        return new APIResponse((int)HttpStatusCode.InternalServerError, null, ex.Message);
    }
}
