using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ronimizy.SpbDotNet.TPC.Common.ContextGeneration;

public class ContextOptionsConfigurator : IAsyncLifetime
{
    private const string User = "postgres";
    private const string Password = "postgres";
    private const string Database = "postgres";

    private readonly PostgreSqlTestcontainer _container;

    public ContextOptionsConfigurator()
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
}