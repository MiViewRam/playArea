using EasyPatch.Common.Implementation;
using IntegrationService.Contracts.Request;
using IntegrationService.Data.Models;

namespace IntegrationService.Providers.PatchMaps
{
    public class IntegrationPatchMap : PatchMapBase<UpdateIntegrationRequest, Integration>
    {
        public IntegrationPatchMap()
        {
            AddPatchStateMapping(x => x.AuthKey, x => x.AuthKey);
            AddPatchStateMapping(x => x.AuthType, x => x.AuthType);
            AddPatchStateMapping(x => x.Endpoint, x => x.Endpoint);
            AddPatchStateMapping(x => x.IsEnabled, x => x.IsEnabled);
            AddPatchStateMapping(x => x.NotifyEmail, x => x.NotifyEmail);
        }
    }
}
