using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using Serilog;

namespace ronimizy.SpbDotNet.TPC.Common.Contexts;

public class ContextFactory<T> : IContextFactory where T : DatabaseContextBase
{
    private readonly Func<DbContextOptions<T>, T> _factory;

    public ContextFactory(
        Func<DbContextOptions<T>, T> factory)
    {
        _factory = factory;
    }

    public async Task<DisposableContext<DatabaseContextBase>> BuildAsync(ContextOptionsConfigurator configurator)
    {
        var builder = new DbContextOptionsBuilder<T>();
        configurator.Configure(builder);

        builder.UseLoggerFactory(LoggerFactory.Create(x => x.AddSerilog()));

        var context = _factory.Invoke(builder.Options);
        await context.Database.EnsureCreatedAsync();

        return new DisposableContext<DatabaseContextBase>(context);
    }

    public override string ToString()
        => typeof(T).Name;
}