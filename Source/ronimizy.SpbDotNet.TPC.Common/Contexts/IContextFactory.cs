using ronimizy.SpbDotNet.TPC.Common.ContextConfiguration;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

namespace ronimizy.SpbDotNet.TPC.Common.Contexts;

public interface IContextFactory
{
    Task<DisposableContext<DatabaseContextBase>> BuildAsync(IContextOptionsConfigurator configurator);
}