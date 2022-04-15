using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IntegrationService.Contracts.Enums;

namespace IntegrationService.Core.Models
{
    public class Run
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public RunStatus Status { get; set; }
        public int ResponseCode { get; set; }
        public string ResultRaw { get; set; }
        public string? ErrorMessage { get; set; }
        public int NewCount { get; set; }
        public int UpdateCount { get; set; }
        public int FailCount { get; set; }
        public DateTimeOffset RunFromDate { get; set; }
        public long TenantId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; }
    }
}
