// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using FluentScanning;
using ronimizy.SpbDotNet.TPC.Benchmarks.Benchmarks;

BenchmarkRunner.Run<SparseTableInsertBenchmark>();
return;

Type[] benchmarkTypes = new AssemblyScanner(typeof(Program))
    .ScanForTypesThat()
    .AreAssignableTo<BenchmarkBase>()
    .AreNotAbstractClasses()
    .AreNotInterfaces()
    .AsTypes()
    .ToArray();

BenchmarkRunner.Run(benchmarkTypes);