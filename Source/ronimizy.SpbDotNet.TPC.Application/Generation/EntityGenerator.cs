using Bogus;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.EmployeeUniforms;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;
using ronimizy.SpbDotNet.TPC.Model.Projects;
using ronimizy.SpbDotNet.TPC.Model.Users;

namespace ronimizy.SpbDotNet.TPC.Application.Generation;

public static class EntityGenerator
{
    public static Faker<User> UserGenerator => new Faker<User>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Name, f => f.Person.FullName);

    public static Faker<Subordinate> SubordinateGenerator => new Faker<Subordinate>()
        .ConfigureEmployee();

    public static Faker<Intern> InternGenerator => new Faker<Intern>()
        .ConfigureEmployee()
        .RuleFor(x => x.InternshipExpiration, f => DateTime.SpecifyKind(f.Date.Future(), DateTimeKind.Utc));

    public static Faker<Manager> ManagerGenerator => new Faker<Manager>()
        .ConfigureEmployee();

    public static Faker<Project> ProjectGenerator => new Faker<Project>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Name, f => f.Commerce.ProductName())
        .RuleFor(x => x.Clients, _ => new List<Employee>());

    public static Faker<ProjectTask> ProjectTaskGenerator => new Faker<ProjectTask>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Name, f => f.Commerce.ProductName())
        .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
        .RuleFor(x => x.StartDate, f => DateTime.SpecifyKind(f.Date.Past(), DateTimeKind.Utc))
        .RuleFor(x => x.EndDate, f => DateTime.SpecifyKind(f.Date.Future(), DateTimeKind.Utc));

    public static Faker<ProjectStage> ProjectStageGenerator => new Faker<ProjectStage>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Name, f => f.Commerce.ProductName());

    public static Faker<CasualEmployeeUniform> CasualEmployeeUniformGenerator => new Faker<CasualEmployeeUniform>()
        .ConfigureEmployeeUniform()
        .RuleFor(x => x.ShirtColorArgb, f => f.Random.Int())
        .RuleFor(x => x.ShirtName, f => f.Company.CompanyName())
        .RuleFor(x => x.ShirtMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.JeansColorArgb, f => f.Random.Int())
        .RuleFor(x => x.JeansName, f => f.Company.CompanyName())
        .RuleFor(x => x.JeansMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.ShoesColorArgb, f => f.Random.Int())
        .RuleFor(x => x.ShoesName, f => f.Company.CompanyName())
        .RuleFor(x => x.ShoesMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.HoodieAllowed, f => f.Random.Bool());
    
    public static Faker<OfficialEmployeeUniform> OfficialEmployeeUniformGenerator => new Faker<OfficialEmployeeUniform>()
        .ConfigureEmployeeUniform()
        .RuleFor(x => x.JacketColorArgb, f => f.Random.Int())
        .RuleFor(x => x.JacketName, f => f.Company.CompanyName())
        .RuleFor(x => x.JacketMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.OfficialPantsColorArgb, f => f.Random.Int())
        .RuleFor(x => x.OfficialPantsName, f => f.Company.CompanyName())
        .RuleFor(x => x.OfficialPantsMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.OfficialShoesColorArgb, f => f.Random.Int())
        .RuleFor(x => x.OfficialShoesName, f => f.Company.CompanyName())
        .RuleFor(x => x.OfficialShoesMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.OfficialShirtColorArgb, f => f.Random.Int())
        .RuleFor(x => x.OfficialShirtName, f => f.Company.CompanyName())
        .RuleFor(x => x.OfficialShirtMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.OfficialTieColorArgb, f => f.Random.Int())
        .RuleFor(x => x.OfficialTieName, f => f.Company.CompanyName())
        .RuleFor(x => x.OfficialTieMostPopularSize, f => f.Random.Int());
    
    public static Faker<DisplayEmployeeUniform> DisplayEmployeeUniformGenerator => new Faker<DisplayEmployeeUniform>()
        .ConfigureEmployeeUniform()
        .RuleFor(x => x.TuxedoColorArgb, f => f.Random.Int())
        .RuleFor(x => x.TuxedoName, f => f.Company.CompanyName())
        .RuleFor(x => x.TuxedoMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.DisplayShirtColorArgb, f => f.Random.Int())
        .RuleFor(x => x.DisplayShirtName, f => f.Company.CompanyName())
        .RuleFor(x => x.DisplayShirtMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.DisplayShoeColorArgb, f => f.Random.Int())
        .RuleFor(x => x.DisplayShoeName, f => f.Company.CompanyName())
        .RuleFor(x => x.DisplayShoeMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.DisplayTieColorArgb, f => f.Random.Int())
        .RuleFor(x => x.DisplayTieName, f => f.Company.CompanyName())
        .RuleFor(x => x.DisplayTieMostPopularSize, f => f.Random.Int())
        .RuleFor(x => x.DisplayBeltColorArgb, f => f.Random.Int())
        .RuleFor(x => x.DisplayBeltName, f => f.Company.CompanyName())
        .RuleFor(x => x.DisplayBeltMostPopularSize, f => f.Random.Int());


    private static Faker<T> ConfigureEmployee<T>(this Faker<T> faker) where T : Employee
        => faker.RuleFor(x => x.Id, f => f.Random.Guid());

    private static Faker<T> ConfigureEmployeeUniform<T>(this Faker<T> faker) where T : EmployeeUniform
        => faker.RuleFor(x => x.Id, f => f.Random.Guid());
}