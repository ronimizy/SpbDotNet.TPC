using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Configurations.ProjectItems;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.HasOne(x => x.Executor);
    }
}