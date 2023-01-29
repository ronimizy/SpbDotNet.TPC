``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Unknown processor
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-SKVIAV : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Size  | Strategy |       Mean |    Error |   StdDev |       Gen0 |      Gen1 | Allocated |
|-------|----------|-----------:|---------:|---------:|-----------:|----------:|----------:|
| 1000  | Tpc      |   158.7 ms |  0.96 ms |  0.85 ms |  1000.0000 |         - |  17.74 MB |
| 1000  | Tph      |   159.9 ms |  1.82 ms |  1.62 ms |  1000.0000 |         - |  19.38 MB |
| 1000  | Tpt      |   286.0 ms |  4.20 ms |  3.72 ms |  2000.0000 |         - |  32.97 MB |
| 10000 | Tpc      | 1,512.0 ms | 26.54 ms | 22.16 ms | 11000.0000 | 4000.0000 | 155.46 MB |
| 10000 | Tph      | 1,652.6 ms | 18.12 ms | 16.95 ms | 12000.0000 | 4000.0000 | 172.77 MB |
| 10000 | Tpt      | 2,889.7 ms | 17.85 ms | 15.82 ms | 22000.0000 | 7000.0000 | 306.96 MB |