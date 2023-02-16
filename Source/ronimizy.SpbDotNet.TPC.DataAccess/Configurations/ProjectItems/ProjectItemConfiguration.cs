using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Configurations.ProjectItems;

public class ProjectItemConfiguration : IEntityTypeConfiguration<ProjectItem>
{
    public void Configure(EntityTypeBuilder<ProjectItem> builder)
    {
        builder.HasOne(x => x.Project).WithMany(x => x.Items);

        builder.HasMany(x => x.Supervisors)
            .WithMany(x => x.SupervisedItems)
            .UsingEntity("ProjectItemSupervisors");
    }
}