using ronimizy.SpbDotNet.TPC.Model.Employees;

namespace ronimizy.SpbDotNet.TPC.Model.ProjectItems;

public class ProjectTask : ProjectItem
{
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Employee? Executor { get; set; }

    public string Description { get; set; }
}