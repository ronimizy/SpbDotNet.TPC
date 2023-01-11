using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

public class TpcDatabaseContext : DatabaseContextBase
{
    public TpcDatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Intern>();
        modelBuilder.Entity<Subordinate>();

        modelBuilder.Entity<ProjectItem>().UseTpcMappingStrategy();
        modelBuilder.Entity<Employee>().UseTpcMappingStrategy();
    }
}