using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebJobExample.WebJob
{
    public class ProcessMessageFunction
    {
        private QueueClient _queueClient;
        public ProcessMessageFunction(IConfiguration configuration)
        {
            _queueClient = new QueueClient(configuration["AzureWebJobsStorage"], "processed");
        }

        public async Task ProcessQueueMessage([QueueTrigger("queue")] string message, ILogger logger)
        {
            await _queueClient.SendMessageAsync($"Processed {message} {DateTime.Now}");
            logger.LogInformation(message);
        }
    }
}