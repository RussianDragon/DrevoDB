using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace DrevoDB.Core.Models;

public class ApiError
{
    [JsonConverter(typeof(StringEnumConverter))]
    public HttpStatusCode StatusCode { get; }
    public Guid ErrorId { get; }
    public string Message { get; }
    public ErrorTypes ErrorType { get; }

    public ApiError(HttpStatusCode statusCode, Guid errorId, string message, ErrorTypes errorType)
    {
        this.StatusCode = statusCode;
        this.ErrorId = errorId;
        this.Message = message;
        this.ErrorType = errorType;
    }
}