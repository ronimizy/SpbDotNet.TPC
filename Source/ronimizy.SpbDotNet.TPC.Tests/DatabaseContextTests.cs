using ronimizy.SpbDotNet.TPC.Common.ContextConfiguration;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;
using ronimizy.SpbDotNet.TPC.Common.Contexts;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Tests.Tools;
using Xunit;
using Xunit.Abstractions;

namespace ronimizy.SpbDotNet.TPC.Tests;

[Collection(Constants.TestCollectionName)]
public class DatabaseContextTests : TestBase
{
    private readonly PgContainerOptionsConfigurator _configurator;

    public DatabaseContextTests(ITestOutputHelper output, PgContainerOptionsConfigurator configurator) : base(output)
    {
        _configurator = configurator;
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task EnsureCreated_Should_ExecuteWithoutErrors(IContextFactory factory)
    {
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);
    }
}