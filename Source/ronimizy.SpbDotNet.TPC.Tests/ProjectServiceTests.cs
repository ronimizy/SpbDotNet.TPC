using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;
using ronimizy.SpbDotNet.TPC.Common.Contexts;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;
using ronimizy.SpbDotNet.TPC.Model.Users;
using ronimizy.SpbDotNet.TPC.Tests.Tools;
using Xunit;
using Xunit.Abstractions;

namespace ronimizy.SpbDotNet.TPC.Tests;

[Collection(Constants.TestCollectionName)]
public class ProjectServiceTests : TestBase
{
    private readonly ContextOptionsConfigurator _configurator;
    private readonly Faker _faker;

    public ProjectServiceTests(ITestOutputHelper output, ContextOptionsConfigurator configurator) : base(output)
    {
        _configurator = configurator;
        _faker = new Faker();
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task CreateProjectAsync_Should_CreateProject(IContextFactory factory)
    {
        // Arrange
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var service = new ProjectService(context.Context, _faker);

        // Act
        await service.CreateProjectAsync();

        // Assert
        var count = await context.Context.Projects.CountAsync();

        count.Should().Be(1);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task PopulateProjectAsync_Should_CreateItems(IContextFactory factory)
    {
        // Arrange
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var service = new ProjectService(context.Context, _faker);

        var project = await service.CreateProjectAsync();

        // Act
        await service.PopulateProjectAsync(project, 10);

        // Assert
        var count = await context.Context.ProjectItems.CountAsync();

        count.Should().Be(10);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task AddProjectClientsAsync_Should_AddClients(IContextFactory factory)
    {
        // Arrange
        const int count = 10;

        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var userService = new UserService(context.Context);
        var employeeService = new EmployeeService(context.Context, _faker);
        var projectService = new ProjectService(context.Context, _faker);

        IReadOnlyCollection<User> users = await userService.AddUsersAsync(count);
        IReadOnlyCollection<Employee> employees = await employeeService.CreateEmployeesAsync(users);

        var project = await projectService.CreateProjectAsync();

        // Act
        await projectService.AddProjectClientsAsync(project, employees);

        // Assert
        project.Clients.Should().HaveCount(count);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetProjectItemsAsync_Should_ReturnItemTree(IContextFactory factory)
    {
        // Arrange
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var service = new ProjectService(context.Context, _faker);

        var project = await service.CreateProjectAsync();
        await service.PopulateProjectAsync(project, 10);

        // Act
        IReadOnlyCollection<ProjectItem> items = await service.GetProjectItemsAsync(project);

        // Assert
        items.Should().NotBeEmpty();
    }
    
    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetProjectItemsSimpleAsync_Should_ReturnFlatProjectItemList(IContextFactory factory)
    {
        // Arrange
        const int count = 10;
        
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var service = new ProjectService(context.Context, _faker);

        var project = await service.CreateProjectAsync();
        await service.PopulateProjectAsync(project, count);

        // Act
        IReadOnlyCollection<ProjectItem> items = await service.GetProjectItemsSimpleAsync(project);

        // Assert
        items.Should().HaveCount(count);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetProjectClientsAsync_Should_ReturnProjectClients(IContextFactory factory)
    {
        // Arrange
        const int count = 10;

        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var userService = new UserService(context.Context);
        var employeeService = new EmployeeService(context.Context, _faker);
        var projectService = new ProjectService(context.Context, _faker);

        IReadOnlyCollection<User> users = await userService.AddUsersAsync(count);
        IReadOnlyCollection<Employee> employees = await employeeService.CreateEmployeesAsync(users);

        var project = await projectService.CreateProjectAsync();
        await projectService.AddProjectClientsAsync(project, employees);

        // Act
        IReadOnlyCollection<Employee> clients = await projectService.GetProjectClientsAsync(project.Id);

        // Assert
        clients.Should().HaveCount(count);
    }
}