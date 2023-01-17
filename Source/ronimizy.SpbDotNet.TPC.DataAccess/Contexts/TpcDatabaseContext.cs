using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.EmployeeUniforms;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

public class TpcDatabaseContext : DatabaseContextBase, IContextOptionsCreatable<TpcDatabaseContext>
{
    public TpcDatabaseContext(DbContextOptions options) : base(options) { }

    public static TpcDatabaseContext Create(DbContextOptions<TpcDatabaseContext> options)
        => new TpcDatabaseContext(options);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Intern>();
        modelBuilder.Entity<Subordinate>();

        modelBuilder.Entity<CasualEmployeeUniform>();
        modelBuilder.Entity<OfficialEmployeeUniform>();
        modelBuilder.Entity<DisplayEmployeeUniform>();

        modelBuilder.Entity<ProjectItem>().UseTpcMappingStrategy();
        modelBuilder.Entity<Employee>().UseTpcMappingStrategy();
        modelBuilder.Entity<EmployeeUniform>().UseTpcMappingStrategy();
    }
}