using System.Net;

namespace TodoCleanArchitecture.Application.DTOs.Common;

public class ApiException
{
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; } = (int)HttpStatusCode.InternalServerError;
    public IEnumerable<ValidationError> Errors { get; set; }
    public string ErrorCode { get; set; } = string.Empty;
}
