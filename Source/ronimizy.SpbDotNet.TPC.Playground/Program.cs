// See https://aka.ms/new-console-template for more information

using Bogus;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Model.Employees;
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

var builder = new DbContextOptionsBuilder<TptDatabaseContext>()
    .UseNpgsql("Host=localhost;Port=5554;Database=postgres;Username=postgres;Password=postgres");

await using var context = new TptDatabaseContext(builder.Options);

await context.Database.EnsureCreatedAsync();

var faker = new Faker();

var userService = new UserService(context);
var employeeService = new EmployeeService(context, faker);
var projectService = new ProjectService(context, faker);

IReadOnlyCollection<User> users = await userService.AddUsersAsync(10);
IReadOnlyCollection<Employee> employees = await employeeService.CreateEmployeesAsync(users);

var project = await projectService.CreateProjectAsync();
await projectService.PopulateProjectAsync(project, 20);

