using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace F_TESTE.Functions;

public class I_TESTE
{
    private readonly ILogger _logger;

    public I_TESTE(ILoggerFactory loggerFactory)
        => _logger = loggerFactory.CreateLogger<H_TESTE>();

    [Function("I_TESTE")]
    public void Run(
        [QueueTrigger("iteste", Connection = "AzureWebJobsStorage")] string message)
    {
        _logger.LogInformation("I_TESTE recebeu: {msg}", message);
    }
}
