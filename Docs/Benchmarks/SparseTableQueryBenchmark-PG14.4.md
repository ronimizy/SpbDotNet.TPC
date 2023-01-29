``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Unknown processor
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-DRNKKC : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```

## Sparse query full hierarchy PostgreSQL 14.4

| Size  | Strategy |      Mean |     Error |    StdDev |  Allocated |
|-------|----------|----------:|----------:|----------:|-----------:|
| 1000  | Tpc      |  4.869 ms | 0.0820 ms | 0.0767 ms |  305.73 KB |
| 1000  | Tph      |  3.727 ms | 0.0351 ms | 0.0311 ms |  298.38 KB |
| 1000  | Tpt      |  5.548 ms | 0.0545 ms | 0.0455 ms |   301.5 KB |
| 10000 | Tpc      | 33.120 ms | 0.2227 ms | 0.2083 ms | 3008.18 KB |
| 10000 | Tph      | 28.999 ms | 0.0973 ms | 0.0862 ms | 2989.39 KB |
| 10000 | Tpt      | 43.200 ms | 0.2233 ms | 0.2089 ms | 3004.55 KB |

## Sparse query single type PostgreSQL 14.4

| Size  | Strategy |      Mean |     Error |    StdDev | Allocated |
|-------|----------|----------:|----------:|----------:|----------:|
| 1000  | Tpc      |  1.627 ms | 0.0323 ms | 0.0345 ms | 105.39 KB |
| 1000  | Tph      |  1.740 ms | 0.0253 ms | 0.0224 ms | 105.38 KB |
| 1000  | Tpt      |  2.196 ms | 0.0377 ms | 0.0334 ms | 106.23 KB |
| 10000 | Tpc      |  9.326 ms | 0.0944 ms | 0.0883 ms | 964.12 KB |
| 10000 | Tph      | 10.009 ms | 0.1540 ms | 0.1286 ms | 960.77 KB |
| 10000 | Tpt      | 13.197 ms | 0.0997 ms | 0.0884 ms | 965.91 KB |