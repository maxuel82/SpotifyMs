using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ProcessaNotificacao
{
    public class ProcessarNotificacaoAzureServiceBus
    {
        [FunctionName("ProcessarNotificacaoAzureServiceBus")]
        public async Task Run( [ServiceBusTrigger("notificacao", Connection = "ServiceBusConnectionString")] 
                               ServiceBusReceivedMessage message, 
                               ILogger log, 
                               ServiceBusMessageActions messageActions)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {message.MessageId}");

            await messageActions.CompleteMessageAsync(message);
            log.LogInformation("Mensagem marcada como completa e removida da fila.");
        }
    }
}



