using CloudSuite.OpenAI.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.OpenAI.Infrastructure.Mappings.EFCore
{
  public class ErrorLogEFCoreMapping : IEntityTypeConfiguration<ErrorLog>
  {
    public void Configure(EntityTypeBuilder<ErrorLog> builder)
    {
      
    }
  }
}