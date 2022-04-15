using IntegrationService.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MiView.DataContext;
using System;
using System.IO;

namespace IntegrationService.Data.Migrations
{
    public class IntegrationServiceContext : AuditDbContext
    {
        public IntegrationServiceContext(DbContextOptions options) : base(options) { }

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
        public virtual DbSet<AccountService_Account> AccountService_Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public class AccountDbContextFactory : IDesignTimeDbContextFactory<IntegrationServiceContext>
        {
            public IntegrationServiceContext CreateDbContext(string[] args)
            {
                var environmentName =
                    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "dev";

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddEnvironmentVariables()
                    .AddJsonFile($"appsettings.{environmentName}.json", true);

                var config = builder.Build();

                var connectionString = config["ConnectionString"];
                var optionsBuilder = new DbContextOptionsBuilder<IntegrationServiceContext>();
                optionsBuilder.UseSqlServer(connectionString);

                return new IntegrationServiceContext(optionsBuilder.Options);
            }
        }
    }
}
