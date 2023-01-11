``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-FNHWWV : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
|           Method |            Factory |     Mean |     Error |    StdDev |   Median | Allocated |
|----------------- |------------------- |---------:|----------:|----------:|---------:|----------:|
| SingleUserInsert | TpcDatabaseContext | 1.684 ms | 0.0776 ms | 0.2202 ms | 1.641 ms |   40.3 KB |
| SingleUserInsert | TphDatabaseContext | 1.754 ms | 0.0623 ms | 0.1736 ms | 1.744 ms |  38.55 KB |
| SingleUserInsert | TptDatabaseContext | 1.718 ms | 0.0622 ms | 0.1754 ms | 1.662 ms |  38.93 KB |
