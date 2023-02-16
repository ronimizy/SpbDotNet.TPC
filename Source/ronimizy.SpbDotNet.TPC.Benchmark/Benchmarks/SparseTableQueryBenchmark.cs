using BenchmarkDotNet.Attributes;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.Model.EmployeeUniforms;

namespace ronimizy.SpbDotNet.TPC.Benchmarks.Benchmarks;

public class SparseTableQueryBenchmark : BenchmarkBase
{
    private EmployeeUniformService _service = default!;

    [Params(1000, 10_000)]
    public int Size { get; set; }
    
    [IterationSetup(Targets = new[]
    {
       nameof(GetAllUniformsBenchmark),
       nameof(GetOfficialUniformsBenchmark),
    })]
    public override void Setup()
    {
        base.Setup();

        _service = new EmployeeUniformService(Context.Context);
        _service.AddEmployeeUniformsAsync(Size).GetAwaiter().GetResult();
    }

    [Benchmark]
    public async Task GetAllUniformsBenchmark()
    {
        await _service.GetEmployeeUniformsAsync();
    }
    
    [Benchmark]
    public async Task GetOfficialUniformsBenchmark()
    {
        await _service.GetEmployeeUniformsAsync<OfficialEmployeeUniform>();
    }
}