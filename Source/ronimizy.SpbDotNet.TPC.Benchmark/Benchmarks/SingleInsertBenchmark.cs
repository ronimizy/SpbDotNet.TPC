using BenchmarkDotNet.Attributes;
using ronimizy.SpbDotNet.TPC.Application.Services;

namespace ronimizy.SpbDotNet.TPC.Benchmarks.Benchmarks;

public class SingleInsertBenchmark : BenchmarkBase
{
    [Benchmark]
    public async Task SingleUserInsert()
    {
        var service = new UserService(Context.Context);

        await service.AddUserAsync();
    }
}