using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.Projects;

namespace ronimizy.SpbDotNet.TPC.Model.ProjectItems;

public abstract class ProjectItem
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Project Project { get; set; }

    public ProjectStage? Parent { get; set; }

    public ICollection<Employee> Supervisors { get; set; }
}