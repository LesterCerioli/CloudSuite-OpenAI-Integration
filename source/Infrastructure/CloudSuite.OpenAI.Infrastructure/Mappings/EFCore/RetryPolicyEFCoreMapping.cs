using CloudSuite.OpenAI.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.OpenAI.Infrastructure.Mappings.EFCore
{
  public class RetryPolicyEFCoreMapping : IEntityTypeConfiguration<RetryPolicy>
  {
    public void Configure(EntityTypeBuilder<RetryPolicy> builder)
    {

    }
  }
}