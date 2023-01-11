using ronimizy.SpbDotNet.TPC.Model.ProjectItems;
using ronimizy.SpbDotNet.TPC.Model.Projects;
using ronimizy.SpbDotNet.TPC.Model.Users;

namespace ronimizy.SpbDotNet.TPC.Model.Employees;

public abstract class Employee
{
    public Guid Id { get; set; }

    public User User { get; set; }

    public Manager? Manager { get; set; }

    public ICollection<Project> Projects { get; set; }

    public ICollection<ProjectItem> SupervisedItems { get; set; }
}