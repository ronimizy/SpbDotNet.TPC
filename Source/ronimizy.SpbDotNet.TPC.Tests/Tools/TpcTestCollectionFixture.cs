using ronimizy.SpbDotNet.TPC.Common.ContextConfiguration;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;
using Xunit;

namespace ronimizy.SpbDotNet.TPC.Tests.Tools;

[CollectionDefinition(Constants.TestCollectionName)]
public class TpcTestCollectionFixture : ICollectionFixture<PgContainerOptionsConfigurator> { }