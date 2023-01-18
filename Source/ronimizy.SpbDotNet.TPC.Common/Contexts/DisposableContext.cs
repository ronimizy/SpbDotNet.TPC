using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Common.ContextConfiguration;

namespace ronimizy.SpbDotNet.TPC.Common.Contexts;

public class DisposableContext<T> : IAsyncDisposable where T : DbContext
{
    private readonly IContextOptionsConfigurator _configurator;

    public DisposableContext(T context, IContextOptionsConfigurator configurator)
    {
        Context = context;
        _configurator = configurator;
    }

    public T Context { get; }

    public async ValueTask DisposeAsync()
    {
        await _configurator.ResetAsync(Context);
        await Context.DisposeAsync();
    }
}