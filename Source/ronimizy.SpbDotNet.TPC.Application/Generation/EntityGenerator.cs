using Bogus;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;
using ronimizy.SpbDotNet.TPC.Model.Projects;
using ronimizy.SpbDotNet.TPC.Model.Users;

namespace ronimizy.SpbDotNet.TPC.Application.Generation;

public static class EntityGenerator
{
    public static Faker<User> UserGenerator { get; } = new Faker<User>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Name, f => f.Person.FullName);

    public static Faker<Subordinate> SubordinateGenerator { get; } = new Faker<Subordinate>()
        .ConfigureEmployee();

    public static Faker<Intern> InternGenerator { get; } = new Faker<Intern>()
        .ConfigureEmployee()
        .RuleFor(x => x.InternshipExpiration, f => DateTime.SpecifyKind(f.Date.Future(), DateTimeKind.Utc));

    public static Faker<Manager> ManagerGenerator { get; } = new Faker<Manager>()
        .ConfigureEmployee();

    public static Faker<Project> ProjectGenerator { get; } = new Faker<Project>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Name, f => f.Commerce.ProductName())
        .RuleFor(x => x.Clients, _ => new List<Employee>());

    public static Faker<ProjectTask> ProjectTaskGenerator { get; } = new Faker<ProjectTask>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Name, f => f.Commerce.ProductName())
        .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
        .RuleFor(x => x.StartDate, f => DateTime.SpecifyKind(f.Date.Past(), DateTimeKind.Utc))
        .RuleFor(x => x.EndDate, f => DateTime.SpecifyKind(f.Date.Future(), DateTimeKind.Utc));

    public static Faker<ProjectStage> ProjectStageGenerator { get; } = new Faker<ProjectStage>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Name, f => f.Commerce.ProductName());

    private static Faker<T> ConfigureEmployee<T>(this Faker<T> faker) where T : Employee
        => faker.RuleFor(x => x.Id, f => f.Random.Guid());
}