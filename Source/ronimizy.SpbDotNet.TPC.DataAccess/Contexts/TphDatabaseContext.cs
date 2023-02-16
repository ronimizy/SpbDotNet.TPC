using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.EmployeeUniforms;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

public class TphDatabaseContext : DatabaseContextBase, IContextOptionsCreatable<TphDatabaseContext>
{
    public TphDatabaseContext(DbContextOptions options) : base(options) { }

    public static TphDatabaseContext Create(DbContextOptions<TphDatabaseContext> options)
        => new TphDatabaseContext(options);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProjectItem>()
            .UseTphMappingStrategy()
            .HasDiscriminator<int>("Discriminator")
            .HasValue<ProjectTask>(1)
            .HasValue<ProjectStage>(2);

        modelBuilder.Entity<Employee>()
            .UseTphMappingStrategy()
            .HasDiscriminator<int>("Discriminator")
            .HasValue<Intern>(1)
            .HasValue<Subordinate>(2)
            .HasValue<Manager>(3);

        modelBuilder.Entity<EmployeeUniform>()
            .UseTphMappingStrategy()
            .HasDiscriminator<int>("Discriminator")
            .HasValue<CasualEmployeeUniform>(1)
            .HasValue<OfficialEmployeeUniform>(2)
            .HasValue<DisplayEmployeeUniform>(3);

        modelBuilder.Entity<Employee>().HasIndex("Discriminator");
    }
}