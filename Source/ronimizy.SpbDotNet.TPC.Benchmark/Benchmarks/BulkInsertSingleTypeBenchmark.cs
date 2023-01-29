using BenchmarkDotNet.Attributes;
using Bogus;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.Users;

namespace ronimizy.SpbDotNet.TPC.Benchmarks.Benchmarks;

public class BulkInsertSingleTypeBenchmark : BenchmarkBase
{
    private IReadOnlyCollection<Intern> _interns = default!;
    private Faker _faker = default!;

    [Params(1000, 10_000)]
    public int Size { get; set; }

    [IterationSetup(Target = nameof(BulkInternInsert))]
    public override void Setup()
    {
        base.Setup();

        _faker = new Faker();
        var userService = new UserService(Context.Context);
        var employeeService = new EmployeeService(Context.Context, _faker);

        IReadOnlyCollection<User> users = userService.AddUsersAsync(Size).GetAwaiter().GetResult();
        Employee[] employees = employeeService.GenerateEmployees(users);

        _interns = employees.OfType<Intern>().ToArray();
    }

    [Benchmark]
    public async Task BulkInternInsert()
    {
        var service = new EmployeeService(Context.Context, _faker);
        await service.CreateEmployeesAsync(_interns);
    }
}