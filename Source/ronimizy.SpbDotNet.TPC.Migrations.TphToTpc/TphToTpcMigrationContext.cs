using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

namespace ronimizy.SpbDotNet.TPC.Migrations.TphToTpc;

public class TphToTpcMigrationContext : TpcDatabaseContext
{
    public TphToTpcMigrationContext(DbContextOptions options) : base(options) { }
}