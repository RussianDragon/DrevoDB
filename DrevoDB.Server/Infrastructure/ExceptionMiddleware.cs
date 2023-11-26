using DrevoDB.Core;
using DrevoDB.Core.Models;
using Newtonsoft.Json;
using System.Net;

namespace DrevoDB.Server.Infrastructure;

class ExceptionMiddleware
{
    private NLog.ILogger Logger { get; } = NLog.LogManager.GetCurrentClassLogger();
    private RequestDelegate Next { get; }

    public ExceptionMiddleware(RequestDelegate next)
    {
        this.Next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, IDrevoTracer drevoTracer)
    {
        try
        {
            await Next(httpContext);
        }
        catch (Exception exception)
        {
            await ProceedException(context: httpContext, 
                                   error: exception,
                                   drevoTracer: drevoTracer);
        }
    }

    private async Task ProceedException(HttpContext context,
                                        Exception error,
                                        IDrevoTracer drevoTracer)
    {
        context.Response.ContentType = $"application/json;charset=utf-8";
        switch (error)
        {
            case ApiException exception:
                {
                    var exceptionType = exception.GetType();
                    object? data = null;
                    if (exceptionType.IsGenericType && exceptionType.GetGenericTypeDefinition() == typeof(ApiException<>))
                    {
                        data = exceptionType.GetProperty("ExceptionData")?.GetValue(exception);
                    }
                    context.Response.StatusCode = (int)exception.StatusCode;
                    LogApiError(logLevel: exception.LogLevel,
                                errorId: exception.ErrorId,
                                drevoTracer: drevoTracer,
                                message: exception.Message,
                                statusCode: exception.StatusCode,
                                context: context,
                                error: error,
                                errorData: data);
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.GetApiError()));
                    break;
                }
            case TaskCanceledException exception:
                {
                    //Request is Canceled
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    Guid errorId = Guid.NewGuid();
                    LogApiError(logLevel: LogMessageLevel.Trace,
                                errorId: errorId,
                                drevoTracer: drevoTracer,
                                message: exception.Message,
                                statusCode: HttpStatusCode.InternalServerError,
                                context: context,
                                error: error,
                                errorData: null);
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiError(HttpStatusCode.InternalServerError, errorId, "Canceled Exception", ErrorTypes.InternalServerError)));
                    break;
                }
            default:
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    Guid errorId = Guid.NewGuid();
                    LogApiError(logLevel: LogMessageLevel.Error,
                                errorId: errorId,
                                drevoTracer: drevoTracer,
                                message: error.Message,
                                statusCode: HttpStatusCode.InternalServerError,
                                context: context,
                                error: error,
                                errorData: null);
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiError(HttpStatusCode.InternalServerError, errorId, "Internal Server Error.", ErrorTypes.InternalServerError)));
                    break;
                }
        }
    }

    private void LogApiError(
       LogMessageLevel logLevel,
       Guid errorId,
       IDrevoTracer drevoTracer,
       string message,
       HttpStatusCode statusCode,
       HttpContext context,
       Exception error,
       object? errorData)
    {
        var logBuilder = new NLog.LogEventBuilder(this.Logger);
        logBuilder.Exception(error)
                  .Message(message)
                  .Property("errorId", errorId)
                  .Property("traceId", drevoTracer.Id)                  
                  .Property("statusCode", statusCode)
                  .Property("errorData", errorData)
                  .Property("request", context.Request)
                  .Log(LevelMapper(logLevel));
        if (logLevel == LogMessageLevel.Fatal || logLevel == LogMessageLevel.Error)
        {
            logBuilder.Property("response", context.Response);
        }
        static NLog.LogLevel LevelMapper(LogMessageLevel logLevel) => logLevel switch
        {
            LogMessageLevel.Trace => NLog.LogLevel.Trace,
            LogMessageLevel.Debug => NLog.LogLevel.Debug,
            LogMessageLevel.Info => NLog.LogLevel.Info,
            LogMessageLevel.Warn => NLog.LogLevel.Warn,
            LogMessageLevel.Error => NLog.LogLevel.Error,
            LogMessageLevel.Fatal => NLog.LogLevel.Fatal,
            LogMessageLevel.Off => NLog.LogLevel.Off,
            _ => throw new NotImplementedException()
        };
    }
}
