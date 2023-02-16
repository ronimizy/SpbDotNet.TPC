``` ini

BenchmarkDotNet=v0.13.4, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-VUEDRE : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
| Size  | Strategy |      Mean |     Error |    StdDev |       Gen0 |       Gen1 | Allocated |
|-------|----------|----------:|----------:|----------:|-----------:|-----------:|----------:|
| 1000  | Tpc      |  35.70 ms |  0.702 ms |  0.656 ms |  2000.0000 |          - |  13.32 MB |
| 1000  | Tph      |  37.92 ms |  0.757 ms |  0.708 ms |  2000.0000 |          - |  14.31 MB |
| 1000  | Tpt      |  61.89 ms |  0.904 ms |  0.801 ms |  3000.0000 |          - |  24.06 MB |
| 10000 | Tpc      | 356.83 ms |  6.934 ms | 14.319 ms | 17000.0000 |  5000.0000 | 110.58 MB |
| 10000 | Tph      | 383.16 ms |  5.818 ms |  8.344 ms | 18000.0000 |  5000.0000 | 121.04 MB |
| 10000 | Tpt      | 681.00 ms | 13.258 ms | 19.843 ms | 34000.0000 | 12000.0000 | 222.09 MB |
