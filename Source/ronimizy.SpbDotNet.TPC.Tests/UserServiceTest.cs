using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;
using ronimizy.SpbDotNet.TPC.Common.Contexts;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Tests.Tools;
using Xunit;
using Xunit.Abstractions;

namespace ronimizy.SpbDotNet.TPC.Tests;

[Collection(Constants.TestCollectionName)]
public class UserServiceTest : TestBase
{
    private readonly ContextOptionsConfigurator _configurator;

    public UserServiceTest(ITestOutputHelper output, ContextOptionsConfigurator configurator) : base(output)
    {
        _configurator = configurator;
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task AddUserAsync_Should_AddUser(IContextFactory factory)
    {
        // Arrange
        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var service = new UserService(context.Context);

        // Act
        await service.AddUserAsync();

        // Assert
        var count = await context.Context.Users.CountAsync();

        count.Should().Be(1);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task AddUsersAsync_Should_AddUsers(IContextFactory factory)
    {
        // Arrange
        const int count = 10;

        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var service = new UserService(context.Context);

        // Act
        await service.AddUsersAsync(count);

        // Assert
        var actualCount = await context.Context.Users.CountAsync();
        actualCount.Should().Be(count);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetUsersAsync_Should_ReturnUsers(IContextFactory factory)
    {
        // Arrange
        const int count = 10;

        await using var context = await factory.BuildAsync(_configurator);

        var service = new UserService(context.Context);

        await service.AddUsersAsync(count);

        // Act
        await service.GetUsersAsync();

        // Assert
        var actualCount = await context.Context.Users.CountAsync();
        actualCount.Should().Be(count);
    }
}