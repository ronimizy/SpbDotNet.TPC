using BenchmarkDotNet.Attributes;
using ronimizy.SpbDotNet.TPC.Application.Services;

namespace ronimizy.SpbDotNet.TPC.Benchmarks.Benchmarks;

public class SparseTableInsertBenchmark : BenchmarkBase
{
    private EmployeeUniformService _service = default!;

    [Params(1000, 10_000)]
    public int Size { get; set; }
    
    [IterationSetup(Targets = new[]
    {
        nameof(AddEmployeeUniformsBenchmark),
    })]
    public override void Setup()
    {
        base.Setup();
        _service = new EmployeeUniformService(Context.Context);
    }

    [Benchmark]
    public async Task AddEmployeeUniformsBenchmark()
    {
        await _service.AddEmployeeUniformsAsync(Size);
    }
}