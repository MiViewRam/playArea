using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IntegrationService.Contracts.Enums;

namespace IntegrationService.Core.Models
{
    public class Integration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public IntegrationPartner IntegrationId { get; set; }
        public bool IsEnabled { get; set; }
        public string Endpoint { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public IntegrationAuthenticationScheme AuthType { get; set; }
        public string AuthKey { get; set; }
        public string NotifyEmail { get; set; }
        public long TenantId { get; set; }

        [ForeignKey(nameof(IntegrationId))]
        public virtual IntegrationType IntegrationType { get; set; }
    }
}
