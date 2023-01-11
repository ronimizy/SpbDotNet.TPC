using System.Collections;
using ronimizy.SpbDotNet.TPC.Common.Contexts;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

namespace ronimizy.SpbDotNet.TPC.Common.ContextGeneration;

public class ContextFactoryGenerator : IEnumerable<IContextFactory>
{
    public IEnumerator<IContextFactory> GetEnumerator()
    {
        yield return new ContextFactory<TphDatabaseContext>(options => new TphDatabaseContext(options));
        yield return new ContextFactory<TptDatabaseContext>(options => new TptDatabaseContext(options));
        yield return new ContextFactory<TpcDatabaseContext>(options => new TpcDatabaseContext(options));
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}