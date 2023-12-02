using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.SQLClient.Controllers;

[ApiController, Route("[controller]")]
public class SQLClientController : ControllerBase
{
    private IServiceProvider Provider { get; }
    private SQLService SQLService => this.Provider.GetRequiredService<SQLService>();
    public SQLClientController(IServiceProvider provider)
    {
        this.Provider = provider;
    }

    [HttpPost("[action]")]
    public Task<DrevoDB.SQLClient.Models.JsonResult> GetJson([FromBody] string query, CancellationToken cancellationToken)
        => this.SQLService.GetJson(query, cancellationToken);
}
