using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegrationService.Core.Models
{
    public class Mapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long IntegrationSettingsId { get; set; }
        public string ExternalId { get; set; }
        public string ExternalName { get; set; }
        public string InternalId { get; set; }
        public long MappingTypeId { get; set; }
        public long TenantId { get; set; }

        [ForeignKey(nameof(IntegrationSettingsId))]
        public virtual Integration Integration { get; set; }
        [ForeignKey(nameof(MappingTypeId))]
        public virtual MappingType MappingType { get; set; }
    }
}
