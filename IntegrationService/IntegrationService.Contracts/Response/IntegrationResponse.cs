using IntegrationService.Contracts.Enums;

namespace IntegrationService.Contracts.Response
{
    public class IntegrationResponse
    {
        public long Id { get; set; }
        public IntegrationAuthenticationScheme AuthType { get; set; }
        public string Endpoint { get; set; }
        public string AuthKey { get; set; }
        public bool IsEnabled { get; set; }
        public IntegrationPartner IntegrationId { get; set; }
        public string NotifyEmail { get; set; }
    }
}
