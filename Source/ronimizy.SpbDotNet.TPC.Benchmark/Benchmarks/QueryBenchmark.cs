using BenchmarkDotNet.Attributes;
using Bogus;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.Model.Users;

namespace ronimizy.SpbDotNet.TPC.Benchmarks.Benchmarks;

public class QueryBenchmark : BenchmarkBase
{
    private EmployeeService _service = default!;
    private Faker _faker = default!;

    [Params(1000, 10_000)]
    public int Size { get; set; }

    [IterationSetup(Targets = new[]
    {
        nameof(SelectFullHierarchyBenchmark),
        nameof(SelectHierarchySliceBenchmark),
        nameof(SelectSingleHierarchyType),
    })]
    public override void Setup()
    {
        base.Setup();

        _faker = new Faker();
        var userService = new UserService(Context.Context);
        _service = new EmployeeService(Context.Context, _faker);

        IReadOnlyCollection<User> users = userService.AddUsersAsync(Size).GetAwaiter().GetResult();
        _service.CreateEmployeesAsync(users).GetAwaiter().GetResult();

        Context.Context.ChangeTracker.Clear();
    }

    [Benchmark]
    public async Task SelectFullHierarchyBenchmark()
    {
        await _service.GetEmployeesAsync();
    }

    [Benchmark]
    public async Task SelectHierarchySliceBenchmark()
    {
        await _service.GetSubordinatesAsync();
    }

    [Benchmark]
    public async Task SelectSingleHierarchyType()
    {
        await _service.GetInternsAsync();
    }
}