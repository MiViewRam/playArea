using Azure.Messaging.EventGrid;
using IntegrationService.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using MiView.DataSubscription;
using System.Reflection;
using System.Threading.Tasks;

namespace IntegrationService.Functions.DataSubscription
{
    public class DataSubscription
    {
        private readonly IDataSubscriptionClient _dataSubscriptionClient;
        public DataSubscription(IDataSubscriptionClient dataSubscriptionClient)
        {

            _dataSubscriptionClient = dataSubscriptionClient;
        }

        [FunctionName(nameof(DataSubscription))]
        public async Task Run([EventGridTrigger] EventGridEvent eventGridEvent)
        {
            await _dataSubscriptionClient.SubscribeAsync(eventGridEvent, Assembly.GetAssembly(typeof(IntegrationServiceContext)));
        }
    }
}

