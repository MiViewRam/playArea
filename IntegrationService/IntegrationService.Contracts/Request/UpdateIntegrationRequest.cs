using System.Collections.Generic;
using EasyPatch.Common.Implementation;
using IntegrationService.Contracts.Enums;

namespace IntegrationService.Contracts.Request
{
    public class UpdateIntegrationRequest : EasyPatchModelMapBase<UpdateIntegrationRequest>
    {

        public UpdateIntegrationRequest() : base(new UpdateIntegrationValidator()) { }

        public string AuthKey { get; set; }
        public IntegrationAuthenticationScheme AuthType { get; set; }
        public string Endpoint { get; set; }
        public bool IsEnabled { get; set; }
        public string NotifyEmail { get; set; }

        public override IEnumerable<KeyValuePair<string, string>> Validate()
        {
            return base.GetValidationErrors(this);
        }

        private class UpdateIntegrationValidator : AbstractPatchValidator<UpdateIntegrationRequest>
        {
            public UpdateIntegrationValidator()
            {
            }
        }
    }
}