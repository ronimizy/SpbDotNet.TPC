``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-QORJXR : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
## Select full hierarchy (Employees)
| Size  | Strategy |      Mean |     Error |    StdDev |    Median |      Gen0 |      Gen1 |   Allocated |
|-------|----------|----------:|----------:|----------:|----------:|----------:|----------:|------------:|
| 1000  | Tpc      |  4.339 ms | 0.0863 ms | 0.1599 ms |  4.326 ms |         - |         - |  2188.09 KB |
| 1000  | Tph      |  4.275 ms | 0.0830 ms | 0.1020 ms |  4.279 ms |         - |         - |  2177.10 KB |
| 1000  | Tpt      |  7.182 ms | 0.1429 ms | 0.1908 ms |  7.149 ms |         - |         - |  3278.68 KB |
| 10000 | Tpc      | 44.943 ms | 0.7141 ms | 0.6680 ms | 45.054 ms | 3000.0000 |         - | 21818.66 KB |
| 10000 | Tph      | 48.507 ms | 0.9382 ms | 1.0039 ms | 48.196 ms | 3000.0000 |         - | 21713.93 KB |
| 10000 | Tpt      | 77.906 ms | 0.6561 ms | 0.5816 ms | 77.911 ms | 5000.0000 | 1000.0000 | 32667.91 KB |

## Select hierarchy slice (Subordinates)
| Size  | Strategy |      Mean |     Error |    StdDev |    Median |      Gen0 | Gen1 |   Allocated |
|-------|----------|----------:|----------:|----------:|----------:|----------:|-----:|------------:|
| 1000  | Tpc      |  2.971 ms | 0.0592 ms | 0.1485 ms |  2.949 ms |         - |    - |  1126.05 KB |
| 1000  | Tph      |  2.747 ms | 0.0637 ms | 0.1764 ms |  2.709 ms |         - |    - |  1118.02 KB |
| 1000  | Tpt      |  4.810 ms | 0.0949 ms | 0.1662 ms |  4.785 ms |         - |    - |  2004.34 KB |
| 10000 | Tpc      | 23.294 ms | 0.4460 ms | 0.4172 ms | 23.270 ms | 1000.0000 |    - | 11124.19 KB |
| 10000 | Tph      | 20.923 ms | 0.4111 ms | 0.3846 ms | 20.941 ms | 1000.0000 |    - | 11045.84 KB |
| 10000 | Tpt      | 42.824 ms | 0.8393 ms | 1.1766 ms | 43.185 ms | 3000.0000 |    - | 19853.09 KB |

## Select single hierarchy type (Interns)
| Size  | Strategy |      Mean |     Error |    StdDev |    Median |      Gen0 | Gen1 |   Allocated |
|-------|----------|----------:|----------:|----------:|----------:|----------:|-----:|------------:|
| 1000  | Tpc      |  2.071 ms | 0.0395 ms | 0.0908 ms |  2.082 ms |         - |    - |   582.63 KB |
| 1000  | Tph      |  2.037 ms | 0.0471 ms | 0.1329 ms |  2.015 ms |         - |    - |   593.11 KB |
| 1000  | Tpt      |  3.038 ms | 0.0607 ms | 0.1579 ms |  3.024 ms |         - |    - |  1129.41 KB |
| 10000 | Tpc      |  8.030 ms | 0.1380 ms | 0.1889 ms |  7.990 ms |         - |    - |  5725.94 KB |
| 10000 | Tph      |  8.215 ms | 0.1610 ms | 0.2506 ms |  8.147 ms |         - |    - |  5830.16 KB |
| 10000 | Tpt      | 26.126 ms | 0.5221 ms | 1.4641 ms | 26.791 ms | 1000.0000 |    - | 11164.36 KB |
