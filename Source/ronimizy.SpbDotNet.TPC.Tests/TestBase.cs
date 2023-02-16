using Bogus;
using ronimizy.SpbDotNet.TPC.Tests.Tools;
using Serilog;
using Xunit.Abstractions;

namespace ronimizy.SpbDotNet.TPC.Tests;

public abstract class TestBase
{
    protected TestBase(ITestOutputHelper output)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.TestOutput(output)
            .CreateLogger();

        Randomizer.Seed = new Random(Constants.Seed);
    }
}