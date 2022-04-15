using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IntegrationService.Contracts.Enums;

namespace IntegrationService.Core.Models
{
    public class MappingType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string DisplayName { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public EntityType EntityType { get; set; }
    }
}
