﻿namespace ApiDoble.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class RandomControllerPar : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Random random)
        {
            string connectionString = "Endpoint=sb://qimparvaleria.servicebus.windows.net/;SharedAccessKeyName=enviar;SharedAccessKey=oAxbS0hxzHlzInCs6xtizoFMdmJBs3qsY/Uf1dQ11sI=;EntityPath=colapar";
            string queueName = "colapar";

            string Mensaje = JsonConvert.SerializeObject(random);  // (Instalar paquete newtonsoft para que funcione el json convert)
            // create a Service Bus client 
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }
            return true;
        }
    }
}
