
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using SpotifyMs.Domain.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpotifyMs.Aplication.Conta
{
    public class AzureServiceBusService
    {
        private string ConnectionString;

        public AzureServiceBusService(IConfiguration configuration)
        {
            this.ConnectionString = configuration["AzureServiceBus:ConnectionString"];
        }

        public async Task SendMessage(NotificacaoAzureServiceBusService notificacao)
        {
            ServiceBusClient client;
            ServiceBusSender sender;

            client = new ServiceBusClient(this.ConnectionString);

            sender = client.CreateSender("notificacao ");

            var body = JsonSerializer.Serialize(notificacao);

            var message = new ServiceBusMessage(body);

            await sender.SendMessageAsync(message); 
        }
    }
}
