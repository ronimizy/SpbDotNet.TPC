using System.Collections;
using ronimizy.SpbDotNet.TPC.Common.ContextGeneration;

namespace ronimizy.SpbDotNet.TPC.Tests.Tools;

public class ContextFactoryGeneratorAdapter : IEnumerable<object[]>
{
    private readonly ContextFactoryGenerator _generator = new ContextFactoryGenerator();

    public IEnumerator<object[]> GetEnumerator()
        => _generator.Select(factory => new object[] { factory }).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}