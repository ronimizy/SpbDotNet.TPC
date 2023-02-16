``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Intel Xeon CPU E5-2667 v2 3.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX
  Job-UVYXDK : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX

InvocationCount=1  UnrollFactor=1  

```

## Sparse query full hierarchy SQL Server 2019

| Size  | Strategy |       Mean |     Error |    StdDev |      Gen0 |   Allocated |
|-------|----------|-----------:|----------:|----------:|----------:|------------:|
| 1000  | Tpc      |  11.859 ms | 0.2029 ms | 0.1898 ms |         - |  1513.26 KB |
| 1000  | Tph      |   9.073 ms | 0.1270 ms | 0.1126 ms |         - |  1392.16 KB |
| 1000  | Tpt      |  15.875 ms | 0.1329 ms | 0.1178 ms |         - |   1511.8 KB |
| 10000 | Tpc      |  91.432 ms | 0.2630 ms | 0.2332 ms | 1000.0000 | 14996.63 KB |
| 10000 | Tph      |  82.738 ms | 0.9170 ms | 0.8129 ms | 1000.0000 | 13863.67 KB |
| 10000 | Tpt      | 100.106 ms | 1.6557 ms | 1.5488 ms | 1000.0000 | 14995.56 KB |

## Sparse query single type SQL Server 2019

| Size  | Strategy |      Mean |     Error |    StdDev | Gen0 |  Allocated |
|-------|----------|----------:|----------:|----------:|-----:|-----------:|
| 1000  | Tpc      |  3.102 ms | 0.0620 ms | 0.0828 ms |    - |  554.14 KB |
| 1000  | Tph      |  5.364 ms | 0.0938 ms | 0.0832 ms |    - |  522.19 KB |
| 1000  | Tpt      |  5.896 ms | 0.1179 ms | 0.2487 ms |    - |  554.73 KB |
| 10000 | Tpc      | 19.785 ms | 0.3932 ms | 0.4829 ms |    - | 5423.56 KB |
| 10000 | Tph      | 26.423 ms | 0.3275 ms | 0.3063 ms |    - | 5065.46 KB |
| 10000 | Tpt      | 24.268 ms | 0.4349 ms | 0.6237 ms |    - | 5458.92 KB |