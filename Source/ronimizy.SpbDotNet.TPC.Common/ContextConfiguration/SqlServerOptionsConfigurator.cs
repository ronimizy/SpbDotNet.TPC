using Microsoft.EntityFrameworkCore;

namespace ronimizy.SpbDotNet.TPC.Common.ContextConfiguration;

public class SqlServerOptionsConfigurator : IContextOptionsConfigurator
{
    public Task InitializeAsync()
        => Task.CompletedTask;

    public Task DisposeAsync()
        => Task.CompletedTask;

    public DbContextOptionsBuilder<T> Configure<T>(DbContextOptionsBuilder<T> builder) where T : DbContext
        => builder.UseSqlServer("");
}