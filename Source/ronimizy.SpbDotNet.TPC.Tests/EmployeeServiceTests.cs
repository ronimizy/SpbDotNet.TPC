using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.Common.ContextConfiguration;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;
using ronimizy.SpbDotNet.TPC.Common.Contexts;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.Users;
using ronimizy.SpbDotNet.TPC.Tests.Tools;
using Xunit;
using Xunit.Abstractions;

namespace ronimizy.SpbDotNet.TPC.Tests;

[Collection(Constants.TestCollectionName)]
public class EmployeeServiceTests : TestBase
{
    private readonly PgContainerOptionsConfigurator _configurator;
    private readonly Faker _faker;

    public EmployeeServiceTests(ITestOutputHelper output, PgContainerOptionsConfigurator configurator) : base(output)
    {
        _configurator = configurator;

        _faker = new Faker();
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task CreateEmployeeAsync_Should_CreateEmployee(IContextFactory factory)
    {
        // Arrange
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var userService = new UserService(context.Context);
        var employeeService = new EmployeeService(context.Context, _faker);

        var user = await userService.AddUserAsync();

        // Act
        await employeeService.CreateEmployeeAsync(user);

        // Assert
        var count = await context.Context.Users.CountAsync();

        count.Should().Be(1);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task CreateEmployeesAsync_Should_CreateEmployees(IContextFactory factory)
    {
        // Arrange
        const int expectedCount = 10;

        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var userService = new UserService(context.Context);
        var employeeService = new EmployeeService(context.Context, _faker);

        IReadOnlyCollection<User> users = await userService.AddUsersAsync(expectedCount);

        // Act
        await employeeService.CreateEmployeesAsync(users);

        // Assert
        var count = await context.Context.Employees.CountAsync();

        count.Should().Be(expectedCount);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetEmployeesAsync_Should_GetAllEmployees(IContextFactory factory)
    {
        // Arrange
        const int expectedCount = 10;

        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var userService = new UserService(context.Context);
        var employeeService = new EmployeeService(context.Context, _faker);

        IReadOnlyCollection<User> users = await userService.AddUsersAsync(expectedCount);
        IReadOnlyCollection<Employee> employees = await employeeService.CreateEmployeesAsync(users);

        // Act
        IReadOnlyCollection<Employee> actualEmployees = await employeeService.GetEmployeesAsync();

        // Assert
        actualEmployees.Count.Should().Be(employees.Count);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetSubordinatesAsync_Should_GetAllSubordinates(IContextFactory factory)
    {
        // Arrange
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var userService = new UserService(context.Context);
        var employeeService = new EmployeeService(context.Context, _faker);

        IReadOnlyCollection<User> users = await userService.AddUsersAsync(10);
        IReadOnlyCollection<Employee> employees = await employeeService.CreateEmployeesAsync(users);

        // Act
        IReadOnlyCollection<Employee> actualEmployees = await employeeService.GetSubordinatesAsync();

        // Assert
        var subordinatesCount = employees.OfType<Subordinate>().Count();

        actualEmployees.Count.Should().Be(subordinatesCount);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetInternsAsync_Should_GetAllInterns(IContextFactory factory)
    {
        // Arrange
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var userService = new UserService(context.Context);
        var employeeService = new EmployeeService(context.Context, _faker);

        IReadOnlyCollection<User> users = await userService.AddUsersAsync(10);
        IReadOnlyCollection<Employee> employees = await employeeService.CreateEmployeesAsync(users);

        // Act
        IReadOnlyCollection<Employee> actualEmployees = await employeeService.GetInternsAsync();

        // Assert
        var count = employees.OfType<Intern>().Count();

        actualEmployees.Count.Should().Be(count);
    }
    
    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetManagersAsync_Should_GetAllManagers(IContextFactory factory)
    {
        // Arrange
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var userService = new UserService(context.Context);
        var employeeService = new EmployeeService(context.Context, _faker);

        IReadOnlyCollection<User> users = await userService.AddUsersAsync(10);
        IReadOnlyCollection<Employee> employees = await employeeService.CreateEmployeesAsync(users);

        // Act
        IReadOnlyCollection<Employee> actualEmployees = await employeeService.GetManagersAsync();

        // Assert
        var count = employees.OfType<Manager>().Count();

        actualEmployees.Count.Should().Be(count);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task LoadFirstManagerWithEmployees_Should_LoadFirstManagerWithEmployees(IContextFactory factory)
    {
        // Arrange
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var userService = new UserService(context.Context);
        var employeeService = new EmployeeService(context.Context, _faker);

        IReadOnlyCollection<User> users = await userService.AddUsersAsync(10);
        await employeeService.CreateEmployeesAsync(users);

        // Act
        var manager = await employeeService.LoadFirstManagerWithEmployees();

        // Assert
        manager.Employees.Should().NotBeEmpty();
    }
}