using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ronimizy.SpbDotNet.TPC.Model.Projects;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Configurations.Projects;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasMany(x => x.Items).WithOne(x => x.Project);

        builder.HasMany(x => x.Clients)
            .WithMany(x => x.Projects)
            .UsingEntity("ProjectClients");
    }
}