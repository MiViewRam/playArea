using System;
using System.Threading.Tasks;
using FunctionAppHelper;
using IntegrationService.Contracts.Enums;
using IntegrationService.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace IntegrationService
{
    public class GetIntegration : FunctionBase
    {
        private readonly IIntegrationProvider _integrationProvider;
        private readonly ILogger _logger;

        public GetIntegration(IIntegrationProvider integrationProvider, ILogger<GetIntegration> logger, IRequestProfile requestProfile) : base(requestProfile)
        {
            _integrationProvider = integrationProvider;
            _logger = logger;
        }

        [FunctionName(nameof(GetIntegration))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "integrations/{id}")] HttpRequest req, string id)
        {
            _logger.LogInformation($"Function {nameof(GetIntegration)} called.");

            try
            {
                if (!Enum.TryParse<IntegrationPartner>(id, out var integrationId))
                {
                    var validOptions = Enum.GetNames(typeof(IntegrationPartner));
                    return new BadRequestObjectResult($"ID must be one of the following: {string.Join(',', validOptions)}");
                }

                PopulateRequestProfile(req);
                var response = await _integrationProvider.GetIntegration(integrationId);
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                return e.CreateErrorResponseObject(_logger);
            }
        }
    }
}
