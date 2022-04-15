using IntegrationService.Contracts.Enums;
using IntegrationService.Contracts.Request;
using IntegrationService.Contracts.Response;

namespace IntegrationService.Providers
{
    public interface IIntegrationProvider
    {
        Task<IntegrationResponse> GetIntegration(IntegrationPartner integrationId);
        Task<IntegrationResponse> UpdateIntegration(IntegrationPartner integrationId, UpdateIntegrationRequest request);
    }
}
