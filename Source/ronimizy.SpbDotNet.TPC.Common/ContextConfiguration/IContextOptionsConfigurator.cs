using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ronimizy.SpbDotNet.TPC.Common.ContextConfiguration;

public interface IContextOptionsConfigurator : IAsyncLifetime
{
    DbContextOptionsBuilder<T> Configure<T>(DbContextOptionsBuilder<T> builder) where T : DbContext;
}