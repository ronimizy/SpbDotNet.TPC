﻿// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using FluentScanning;
using ronimizy.SpbDotNet.TPC.Benchmarks.Benchmarks;

Type[] benchmarkTypes = new AssemblyScanner(typeof(Program))
    .ScanForTypesThat()
    .AreAssignableTo<BenchmarkBase>()
    .AreNotAbstractClasses()
    .AreNotInterfaces()
    .AsTypes()
    .ToArray();

var config = new ManualConfig();
config.AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
config.AddExporter(DefaultConfig.Instance.GetExporters().ToArray());
config.AddDiagnoser(DefaultConfig.Instance.GetDiagnosers().ToArray());
config.AddAnalyser(DefaultConfig.Instance.GetAnalysers().ToArray());
config.AddJob(DefaultConfig.Instance.GetJobs().ToArray());
config.AddValidator(DefaultConfig.Instance.GetValidators().ToArray());
config.UnionRule = ConfigUnionRule.AlwaysUseGlobal;

BenchmarkRunner.Run(benchmarkTypes);