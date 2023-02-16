using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.EmployeeUniforms;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

public class TptDatabaseContext : DatabaseContextBase, IContextOptionsCreatable<TptDatabaseContext>
{
    public TptDatabaseContext(DbContextOptions options) : base(options) { }

    public static TptDatabaseContext Create(DbContextOptions<TptDatabaseContext> options)
        => new TptDatabaseContext(options);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Intern>();
        modelBuilder.Entity<Subordinate>();

        modelBuilder.Entity<CasualEmployeeUniform>();
        modelBuilder.Entity<OfficialEmployeeUniform>();
        modelBuilder.Entity<DisplayEmployeeUniform>();

        modelBuilder.Entity<ProjectItem>().UseTptMappingStrategy();
        modelBuilder.Entity<Employee>().UseTptMappingStrategy();
        modelBuilder.Entity<EmployeeUniform>().UseTptMappingStrategy();
    }
}