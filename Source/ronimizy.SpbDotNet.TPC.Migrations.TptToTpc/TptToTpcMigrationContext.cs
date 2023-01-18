using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

namespace ronimizy.SpbDotNet.TPC.Migrations.TptToTpc;

public class TptToTpcMigrationContext : TpcDatabaseContext
{
    public TptToTpcMigrationContext(DbContextOptions options) : base(options) { }
}