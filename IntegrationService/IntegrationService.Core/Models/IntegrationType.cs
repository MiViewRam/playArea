using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IntegrationService.Contracts.Enums;

namespace IntegrationService.Core.Models
{
    public class IntegrationType
    {
        [Key]
        [Column(TypeName = "nvarchar(32)")]
        public IntegrationPartner Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Version { get; set; }
    }
}
