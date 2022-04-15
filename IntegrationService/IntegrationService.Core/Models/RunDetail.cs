using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IntegrationService.Contracts.Enums;

namespace IntegrationService.Core.Models
{
    public class RunDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long RunId { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public DetailStatus Status { get; set; }
        public string ResultRaw { get; set; }
        public string ResultParsed { get; set; }
        public string Error { get; set; }
        public string Log { get; set; }
        public bool IsNew { get; set; }
        public long RelatedEntityId { get; set; }
        public long TenantId { get; set; }

        [ForeignKey(nameof(RunId))]
        public virtual Run Run { get; set; }
    }
}
