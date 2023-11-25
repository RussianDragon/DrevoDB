using DrevoDB.Core.Models;
using System.Net;

namespace DrevoDB.Core;

public class ApiException<T> : ApiException
{
    public T ExceptionData { get; }

    public ApiException(T exceptionData)
        : base()
    {
        ExceptionData = exceptionData;
    }

    public ApiException(HttpStatusCode statusCode, T exceptionData, string message, LogMessageLevel? logLevel = null)
        : base(statusCode, message, logLevel)
    {
        ExceptionData = exceptionData;
    }

    public ApiException(HttpStatusCode statusCode, T exceptionData, string message, ErrorTypes errorType, LogMessageLevel? logLevel = null)
        : base(statusCode, message, errorType, logLevel)
    {
        ExceptionData = exceptionData;
    }

    public ApiException(HttpStatusCode statusCode, T exceptionData, string message, ErrorTypes errorType, Exception innerException, LogMessageLevel? logLevel = null)
        : base(statusCode, message, errorType, logLevel)
    {
        ExceptionData = exceptionData;
    }

    public override ApiError GetApiError() => new ApiErrorWithDetails<T>(this.StatusCode, ExceptionData, this.ErrorId, this.Message, this.ErrorType);
}