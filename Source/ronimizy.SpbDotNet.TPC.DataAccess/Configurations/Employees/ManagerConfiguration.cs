using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ronimizy.SpbDotNet.TPC.Model.Employees;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Configurations.Employees;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.HasMany(x => x.Employees);
    }
}