using DrevoDB.Core.Models;
using System.Net;

namespace DrevoDB.Core;
public class ApiException : Exception
{
    public Guid ErrorId { get; } = Guid.NewGuid();
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
    public LogMessageLevel LogLevel { get; } = LogMessageLevel.Error;
    public ErrorTypes ErrorType { get; } = ErrorTypes.InternalServerError;

    public ApiException() : base() { }
    public ApiException(string message, LogMessageLevel? logLevel = null) : base(message)
    {
        this.LogLevel = logLevel ?? LogMessageLevel.Error;
    }
    public ApiException(HttpStatusCode statusCode, LogMessageLevel? logLevel = null) : base()
    {
        this.StatusCode = statusCode;
        this.LogLevel = logLevel ?? LogMessageLevel.Error;
    }
    public ApiException(HttpStatusCode statusCode, string message, LogMessageLevel? logLevel = null) : base(message)
    {
        this.StatusCode = statusCode;
        this.LogLevel = logLevel ?? LogMessageLevel.Error;
    }
    public ApiException(HttpStatusCode statusCode, string message, ErrorTypes errorType, LogMessageLevel? logLevel = null) : this(statusCode, message, logLevel)
    {
        this.ErrorType = errorType;
        this.LogLevel = logLevel ?? LogMessageLevel.Error;
    }
    public ApiException(HttpStatusCode statusCode, string message, ErrorTypes errorType, Exception innerException, LogMessageLevel? logLevel = null)
        : base(message, innerException)
    {
        this.StatusCode = statusCode;
        this.ErrorType = errorType;
        this.LogLevel = logLevel ?? LogMessageLevel.Error;
    }

    public virtual ApiError GetApiError() => new ApiError(this.StatusCode, this.ErrorId, this.Message, this.ErrorType);
}
