using MiView.DataSubscription.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegrationService.Core.Models
{
    public class AccountService_Account : DataSubscriptionBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string Code { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string StoreNumber { get; set; }
        public string InternalNumber { get; set; }
        public long AccountTypeId { get; set; }
        public long StatusId { get; set; }
        public long? ParentId { get; set; }
        public string AddressHouseNumber { get; set; }
        public string AddressStreetNumber { get; set; }
        public string AddressAdditionalInfo { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZipCode { get; set; }
        public string BillingHouseNumber { get; set; }
        public string BillingStreetNumber { get; set; }
        public string BillingAdditionalInfo { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZipCode { get; set; }
        public string ExternalId { get; set; }
        public string LegalName { get; set; }
        public long PaymentTermsId { get; set; }
        public long PaymentBillingRateId { get; set; }
        public long BillingRateId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public long TenantId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
    }
}
