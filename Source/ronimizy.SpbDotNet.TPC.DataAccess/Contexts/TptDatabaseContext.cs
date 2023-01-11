using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

public class TptDatabaseContext : DatabaseContextBase
{
    public TptDatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Intern>();
        modelBuilder.Entity<Subordinate>();

        modelBuilder.Entity<ProjectItem>().UseTptMappingStrategy();
        modelBuilder.Entity<Employee>().UseTptMappingStrategy();
    }
}