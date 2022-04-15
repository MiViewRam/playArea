using FunctionAppHelper;
using IntegrationService.Contracts.Enums;
using IntegrationService.Contracts.Request;
using IntegrationService.Contracts.Response;
using IntegrationService.Data;
using Microsoft.EntityFrameworkCore;
using MiView.Core.Exceptions;

namespace IntegrationService.Providers
{
    public class IntegrationProvider : IIntegrationProvider
    {
        private readonly IntegrationServiceContext _context;
        private readonly IRequestProfile _requestProfile;

        public IntegrationProvider(IntegrationServiceContext context, IRequestProfile requestProfile)
        {
            _context = context;
            _requestProfile = requestProfile;
        }

        public async Task<IntegrationResponse> GetIntegration(IntegrationPartner id)
        {
            var integration = await _context.Integrations.Where(x => x.IntegrationId == id)
                .Select(x => new IntegrationResponse
                {
                    Id = x.Id,
                    AuthType = x.AuthType,
                    Endpoint = x.Endpoint,
                    AuthKey = x.AuthKey,
                    IsEnabled = x.IsEnabled,
                    IntegrationId = x.IntegrationId,
                    NotifyEmail = x.NotifyEmail
                }).SingleOrDefaultAsync();
            if (integration == null)
            {
                throw new DatabaseObjectNotFoundException("Integration", "IntegrationId", id.ToString());
            }

            return integration;
        }

        public async Task<IntegrationResponse> UpdateIntegration(IntegrationPartner integrationId, UpdateIntegrationRequest request)
        {
            var integration = await _context.Integrations.SingleOrDefaultAsync(x => x.IntegrationId == integrationId);
            if (integration == null)
            {
                throw new DatabaseObjectNotFoundException("Integration", "IntegrationId", integrationId.ToString());
            }

            request.Patch(integration);

            await _context.SaveChangesAsync();

            return await GetIntegration(integrationId);
        }
    }
}
