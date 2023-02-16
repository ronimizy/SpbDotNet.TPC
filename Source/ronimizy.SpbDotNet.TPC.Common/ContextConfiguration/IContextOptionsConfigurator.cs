using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using Xunit;

namespace ronimizy.SpbDotNet.TPC.Common.ContextConfiguration;

public interface IContextOptionsConfigurator : IAsyncLifetime
{
    DbContextOptionsBuilder<T> Configure<T>(DbContextOptionsBuilder<T> builder) where T : DbContext;

    Task ResetAsync(DbContext context);
}