using BenchmarkDotNet.Attributes;
using Bogus;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.Users;

namespace ronimizy.SpbDotNet.TPC.Benchmarks.Benchmarks;

public class BulkInsertBenchmark : BenchmarkBase
{
    private IReadOnlyCollection<Employee> _employees = default!;
    private Faker _faker = default!;

    [Params(1000, 10_000)]
    public int Size { get; set; }

    [IterationSetup(Target = nameof(BulkEmployeeInsert))]
    public override void Setup()
    {
        base.Setup();

        _faker = new Faker();
        var userService = new UserService(Context.Context);
        var employeeService = new EmployeeService(Context.Context, _faker);

        IReadOnlyCollection<User> users = userService.AddUsersAsync(Size).GetAwaiter().GetResult();
        _employees = employeeService.GenerateEmployees(users);
    }

    [Benchmark]
    public async Task BulkEmployeeInsert()
    {
        var service = new EmployeeService(Context.Context, _faker);
        await service.CreateEmployeesAsync(_employees);
    }
}