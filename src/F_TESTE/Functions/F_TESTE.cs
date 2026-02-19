using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

public class FTesteFunction
{
    private readonly ILogger _logger;

    public FTesteFunction(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FTesteFunction>();
    }

    [Function("F_TESTE")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("F_TESTE triggered.");
        var res = req.CreateResponse(HttpStatusCode.OK);
        res.WriteString("OK");
        return res;
    }
}
