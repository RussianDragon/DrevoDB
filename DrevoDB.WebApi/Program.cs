using DrevoDB.Core;
using DrevoDB.WebApi.Infrastructure;
using DrevoDB.WebApi.Infrastructure.Models;
using DrevoDB.WebApi.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.Web;

var logger = LogManager.Setup()
                       .LoadConfigurationFromAppSettings()
                       .GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

#region NLog
builder.Logging.ClearProviders();
builder.Host.UseNLog(new NLogAspNetCoreOptions
{
    RemoveLoggerFactoryFilter = false
});
#endregion

#region Common setting
JsonConvert.DefaultSettings = () =>
{
    //jsonOutputFormatter.SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-6"));
    return new JsonSerializerSettings()
    {
        DateFormatString = "yyyy-MM-ddTHH:mm:ss.ffffK",
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
};
#endregion

builder.Services.AddControllers().AddNewtonsoftJson();

#region WebApi setting
builder.Services.AddScoped<IDrevoTracer, DrevoTracer>();

var webApiSettings = builder.Configuration.GetRequiredSection("WebApiSettings").Get<WebApiSettings>()!;
builder.Services.AddSingleton(webApiSettings);
#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<TraceMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<CancelAfterMiddleware>();

// Configure the HTTP request pipeline.
if (webApiSettings.SwaggerEnabled)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
