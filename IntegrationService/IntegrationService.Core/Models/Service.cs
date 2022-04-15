using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegrationService.Core.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ServiceTypeName { get; set; }
        public bool IsEnabled { get; set; }
        public TimeSpan Interval { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string RunDays { get; set; }
        public DateTimeOffset RunFromDate { get; set; }
        public long TenantId { get; set; }

        [ForeignKey(nameof(ServiceTypeName))]
        public virtual ServiceType ServiceType { get; set; }
    }
}
