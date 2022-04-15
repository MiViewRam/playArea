using IntegrationService.Data.Models;
using Microsoft.EntityFrameworkCore;
using MiView.DataContext;

namespace IntegrationService.Data
{
    public class IntegrationServiceContext : AuditDbContext
    {
        public IntegrationServiceContext(DbContextOptions options) : base(options)
        {
        }

        //Internal Tables
        public virtual DbSet<IntegrationType> IntegrationTypes { get; set; }
        public virtual DbSet<Integration> Integrations { get; set; }
        public virtual DbSet<Mapping> Mappings { get; set; }
        public virtual DbSet<MappingType> MappingTypes { get; set; }
        public virtual DbSet<Run> Runs { get; set; }
        public virtual DbSet<RunDetail> RunDetails { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }

        //Remote Tables
        public virtual DbSet<AccountService_Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
