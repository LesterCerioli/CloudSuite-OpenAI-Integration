using CloudSuite.OpenAI.Modules.Domain.Models;
using CloudSuite.OpenAI.Infrastructure.Mappings.EFCore;
using FluentValidation.Results;

using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;

namespace CloudSuite.OpenAI.Infrastructure.Context
{
  public class OpenAIDbContext : DbContext
  {
    public OpenAIDbContext(DbContextOptions<OpenAIDbContext> options) : base(options)
    {
      ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
      ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<ErrorLog> ErrorLogs { get; set; }
    public DbSet<Prompt> Prompts { get; set; }
    public DbSet<RetryPolicy> RetryPolicies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Ignore<ValidationResult>();
      modelBuilder.Ignore<Event>();

      foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
        e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
        property.SetColumnType("varchar(100)");

      modelBuilder.ApplyConfiguration(new ErrorLogEFCoreMapping());

      modelBuilder.ApplyConfiguration(new PromptEFCoreMapping());

      modelBuilder.ApplyConfiguration(new RetryPolicyEFCoreMapping());

      modelBuilder.Entity<ErrorLog>(c =>
      {
        c.ToTable("msopenai_errorlogs");
      });

      modelBuilder.Entity<Prompt>(c =>
      {
        c.ToTable("msopenai_prompts");
      });

      modelBuilder.Entity<RetryPolicy>(c =>
      {
        c.ToTable("msopenai_retrypolicies");
      });

      base.OnModelCreating(modelBuilder);
    }
  }
}