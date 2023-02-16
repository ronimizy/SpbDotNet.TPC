// See https://aka.ms/new-console-template for more information

using Bogus;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Model.Users;

// var sql = """
// """;
//
// var parameters = """
//
// """;
//
// var inlined = ParameterInliner.InlineParameters(sql, parameters);
// Console.WriteLine(inlined);
//
// return;

Randomizer.Seed = new Random(101);

await InitDatabase<TpcDatabaseContext>();

async Task InitDatabase<T>() where T : DatabaseContextBase, IContextOptionsCreatable<T>
{
    DbContextOptionsBuilder<T> builder = new DbContextOptionsBuilder<T>()
        .UseNpgsql("Host=localhost;Port=5554;Database=postgres;Username=postgres;Password=postgres");

    await using var context = T.Create(builder.Options);

    await context.Database.EnsureCreatedAsync();

    var faker = new Faker();

    var userService = new UserService(context);
    var employeeService = new EmployeeService(context, faker);
    var projectService = new ProjectService(context, faker);
    var employeeUniformService = new EmployeeUniformService(context);

    IReadOnlyCollection<User> users = await userService.AddUsersAsync(10);
    await employeeService.CreateEmployeesAsync(users);

    var project = await projectService.CreateProjectAsync();
    await projectService.PopulateProjectAsync(project, 20);

    await employeeUniformService.AddEmployeeUniformsAsync(100);
}