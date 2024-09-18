using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CloudSuite.OpenAI.Infrastructure.Context
{
  public class DesignTimeOpenAIContextFactory : IDesignTimeDbContextFactory<OpenAIDbContext>
  {
    public OpenAIDbContext CreateDbContext(string[] args)
    {
      var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var optionsBuilder = new DbContextOptionsBuilder<OpenAIDbContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      optionsBuilder.UseNpgsql(connectionString);

      return new OpenAIDbContext(optionsBuilder.Options);
    }
  }
}