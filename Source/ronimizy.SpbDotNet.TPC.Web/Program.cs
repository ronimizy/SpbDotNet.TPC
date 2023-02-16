using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Migrations.TphToTpc;
using ronimizy.SpbDotNet.TPC.Migrations.TptToTpc;

var builder = WebApplication.CreateBuilder(args);

ConfigureContext<TphToTpcMigrationContext>(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await using var context = scope.ServiceProvider.GetRequiredService<DatabaseContextBase>();
    await context.Database.MigrateAsync();
}

app.Run();

static void ConfigureContext<T>(IServiceCollection collection) where T : DatabaseContextBase
{
    collection.AddDbContext<T>(x
        => x.UseNpgsql("Host=localhost;Port=5554;Database=postgres;Username=postgres;Password=postgres"));

    collection.AddScoped<DatabaseContextBase>(x => x.GetRequiredService<T>());
}