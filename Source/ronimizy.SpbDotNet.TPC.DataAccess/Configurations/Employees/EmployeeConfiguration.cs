using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ronimizy.SpbDotNet.TPC.Model.Employees;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Configurations.Employees;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasOne(x => x.User);
        builder.HasMany(x => x.Projects).WithMany(x => x.Clients);
        builder.HasOne(x => x.Manager).WithMany(x => x.Employees);
        builder.HasMany(x => x.SupervisedItems).WithMany(x => x.Supervisors);
    }
}