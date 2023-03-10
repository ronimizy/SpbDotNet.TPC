using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

namespace ronimizy.SpbDotNet.TPC.Common.ContextConfiguration;

public class PgContainerOptionsConfigurator : IContextOptionsConfigurator
{
    private const string User = "postgres";
    private const string Password = "postgres";
    private const string Database = "postgres";

    private readonly PostgreSqlTestcontainer _container;

    public PgContainerOptionsConfigurator()
    {
        _container = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new PostgreSqlTestcontainerConfiguration
            {
                Database = Database,
                Username = User,
                Password = Password,
            })
            .WithCreateContainerParametersModifier(x => { x.HostConfig.CPUCount = -1; })
            .Build();
    }

    public async Task InitializeAsync()
        => await _container.StartAsync();

    public async Task DisposeAsync()
        => await _container.DisposeAsync();

    public DbContextOptionsBuilder<T> Configure<T>(DbContextOptionsBuilder<T> builder) where T : DbContext
        => builder.UseNpgsql(_container.ConnectionString).EnableSensitiveDataLogging();

    public async Task ResetAsync(DbContext context)
    {
        await context.Database.ExecuteSqlRawAsync("""



DROP SCHEMA public CASCADE;
CREATE SCHEMA public;

GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO public;



""");
    }
}