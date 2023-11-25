using System.Net;

namespace DrevoDB.Core.Models;

public class ApiErrorWithDetails<TProblemDetails> : ApiError
{
    public ApiErrorWithDetails(HttpStatusCode statusCode, TProblemDetails problemDetails, Guid errorId, string message, ErrorTypes errorType)
        : base(statusCode, errorId, message, errorType)
    {
        ProblemDetails = problemDetails;
    }

    public TProblemDetails ProblemDetails { get; }
}