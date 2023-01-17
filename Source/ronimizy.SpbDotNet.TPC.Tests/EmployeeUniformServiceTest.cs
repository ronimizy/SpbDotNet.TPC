using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Services;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;
using ronimizy.SpbDotNet.TPC.Common.Contexts;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Model.EmployeeUniforms;
using ronimizy.SpbDotNet.TPC.Tests.Tools;
using Xunit;
using Xunit.Abstractions;

namespace ronimizy.SpbDotNet.TPC.Tests;

[Collection(Constants.TestCollectionName)]
public class EmployeeUniformServiceTest : TestBase
{
    private readonly ContextOptionsConfigurator _configurator;

    public EmployeeUniformServiceTest(ITestOutputHelper output, ContextOptionsConfigurator configurator) : base(output)
    {
        _configurator = configurator;
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task AddEmployeeUniformsAsync_Should_AddEmployeeUniforms(IContextFactory factory)
    {
        // Arrange
        const int expectedCount = 12;

        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var service = new EmployeeUniformService(context.Context);

        // Act
        await service.AddEmployeeUniformsAsync(12);

        // Assert
        var count = await context.Context.EmployeeUniforms.CountAsync();

        count.Should().Be(expectedCount);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetEmployeeUniformsAsync_Should_ReturnAllUniforms(IContextFactory factory)
    {
        // Arrange
        const int expectedCount = 12;

        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var service = new EmployeeUniformService(context.Context);
        await service.AddEmployeeUniformsAsync(12);

        // Act
        IReadOnlyCollection<EmployeeUniform> uniforms = await service.GetEmployeeUniformsAsync();

        // Assert
        uniforms.Count.Should().Be(expectedCount);
    }

    [Theory]
    [ClassData(typeof(ContextFactoryGeneratorAdapter))]
    public async Task GetEmployeeUniformsAsync_Should_ReturnSpecifiedUniforms(IContextFactory factory)
    {
        // Arrange
        const int expectedCount = 12;

        await using DisposableContext<DatabaseContextBase> context = await factory.BuildAsync(_configurator);

        var service = new EmployeeUniformService(context.Context);
        await service.AddEmployeeUniformsAsync(12);

        // Act
        IReadOnlyCollection<OfficialEmployeeUniform> uniforms = await service
            .GetEmployeeUniformsAsync<OfficialEmployeeUniform>();

        // Assert
        uniforms.Count.Should().Be(expectedCount / 3);
    }
}