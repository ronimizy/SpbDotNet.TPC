using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;
using ronimizy.SpbDotNet.TPC.Model.Projects;
using ronimizy.SpbDotNet.TPC.Model.Users;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

public abstract class DatabaseContextBase : DbContext
{
    protected DatabaseContextBase(DbContextOptions options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectItem> ProjectItems => Set<ProjectItem>();
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
}