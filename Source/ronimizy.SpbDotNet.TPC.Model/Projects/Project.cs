using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;

namespace ronimizy.SpbDotNet.TPC.Model.Projects;

public class Project
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<ProjectItem> Items { get; set; }
    
    public ICollection<Employee> Clients { get; set; }
}