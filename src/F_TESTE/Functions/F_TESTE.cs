using System.Net;
using System.Text;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace F_TESTE.Functions;

public class F_TESTE
{
    private readonly ILogger<F_TESTE> _logger;

    public F_TESTE(ILogger<F_TESTE> logger)
    {
        _logger = logger;
    }

    [Function("F_TESTE")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
    {
        var body = await new StreamReader(req.Body).ReadToEndAsync();
        var queueName = "g_teste"; // <= nome válido (minúsculo)

        // Usa o mesmo storage definido na Function App
        var conn = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        if (string.IsNullOrWhiteSpace(conn))
        {
            var bad = req.CreateResponse(HttpStatusCode.InternalServerError);
            await bad.WriteStringAsync("AzureWebJobsStorage não encontrado.");
            return bad;
        }

        var queueClient = new QueueClient(
            conn,
            queueName,
            new QueueClientOptions { MessageEncoding = QueueMessageEncoding.Base64 });

        await queueClient.CreateIfNotExistsAsync();
        await queueClient.SendMessageAsync(body);

        _logger.LogInformation("Mensagem enviada para a fila {queueName}", queueName);

        var ok = req.CreateResponse(HttpStatusCode.OK);
        await ok.WriteStringAsync($"Enfileirado em {queueName}");
        return ok;
    }
}
