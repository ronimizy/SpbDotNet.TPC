using Microsoft.EntityFrameworkCore;

namespace ronimizy.SpbDotNet.TPC.Common.Contexts;

public class DisposableContext<T> : IAsyncDisposable where T : DbContext
{
    public DisposableContext(T context)
    {
        Context = context;
    }

    public T Context { get; }

    public async ValueTask DisposeAsync()
    {
        await Context.Database.ExecuteSqlRawAsync("""



DROP SCHEMA public CASCADE;
CREATE SCHEMA public;

GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO public;



""");

        await Context.DisposeAsync();
    }
}