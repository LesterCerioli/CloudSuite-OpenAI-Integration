using CloudSuite.OpenAI.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.OpenAI.Infrastructure.Mappings.EFCore
{
  public class PromptEFCoreMapping : IEntityTypeConfiguration<Prompt>
  {
    public void Configure(EntityTypeBuilder<Prompt> builder)
    {

    }
  }
}