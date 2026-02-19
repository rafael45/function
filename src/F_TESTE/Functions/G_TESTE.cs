using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace F_TESTE.Functions;

public class G_TESTE
{
    private readonly ILogger _logger;

    public G_TESTE(ILoggerFactory loggerFactory)
        => _logger = loggerFactory.CreateLogger<G_TESTE>();

    [Function("G_TESTE")]
    public void Run(
        [QueueTrigger("gteste", Connection = "AzureWebJobsStorage")] string message)
    {
        _logger.LogInformation("G_TESTE recebeu: {msg}", message);
    }
}
