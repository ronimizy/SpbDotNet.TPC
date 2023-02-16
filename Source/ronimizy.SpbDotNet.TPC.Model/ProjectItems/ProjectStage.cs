namespace ronimizy.SpbDotNet.TPC.Model.ProjectItems;

public class ProjectStage : ProjectItem
{
    public ICollection<ProjectItem> Children { get; set; }
}