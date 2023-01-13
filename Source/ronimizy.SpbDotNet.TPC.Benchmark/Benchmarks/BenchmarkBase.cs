using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Bogus;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;
using ronimizy.SpbDotNet.TPC.Common.Contexts;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

namespace ronimizy.SpbDotNet.TPC.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.Method)]
public abstract class BenchmarkBase
{
    private ContextOptionsConfigurator _configurator = default!;
    protected DisposableContext<DatabaseContextBase> Context = default!;

    [ParamsSource(nameof(ContextFactorySource))]
    public IContextFactory Factory { get; set; } = default!;

    public static IEnumerable<IContextFactory> ContextFactorySource => new ContextFactoryGenerator();

    [GlobalSetup]
    public async Task GlobalSetup()
    {
        _configurator = new ContextOptionsConfigurator();
        await _configurator.InitializeAsync();
    }

    [GlobalCleanup]
    public async Task GlobalCleanup()
        => await _configurator.DisposeAsync();

    [IterationSetup]
    public virtual void Setup()
    {
        Context = Factory.BuildAsync(_configurator).GetAwaiter().GetResult();
        Randomizer.Seed = new Random(101);
    }

    [IterationCleanup]
    public void Cleanup()
    {
        async Task Dispose()
            => await Context.DisposeAsync();

        Dispose().GetAwaiter().GetResult();
    }
}