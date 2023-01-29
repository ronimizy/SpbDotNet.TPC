using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Model.Employees;
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

        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Manager>().ToTable("Managers");
        modelBuilder.Entity<Subordinate>().ToTable("Subordinates");
        modelBuilder.Entity<Intern>().ToTable("Interns");

        modelBuilder.Entity<ProjectItem>().ToTable("ProjectItems");
        modelBuilder.Entity<ProjectTask>().ToTable("ProjectTasks");
        modelBuilder.Entity<ProjectStage>().ToTable("ProjectStages");
    }
}