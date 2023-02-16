``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Intel Xeon CPU E5-2667 v2 3.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX
  Job-UVYXDK : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX

InvocationCount=1  UnrollFactor=1  

```

## Sparse insert SQL Server 2019

| Size  | Strategy |       Mean |     Error |    StdDev |       Gen0 |       Gen1 | Allocated |
|-------|----------|-----------:|----------:|----------:|-----------:|-----------:|----------:|
| 1000  | Tpc      |   543.0 ms |   1.37 ms |   1.21 ms |  2000.0000 |  1000.0000 |  37.25 MB |
| 1000  | Tph      |   613.9 ms |   1.92 ms |   1.70 ms |  3000.0000 |  1000.0000 |  38.22 MB |
| 1000  | Tpt      |   628.6 ms |   5.93 ms |   4.95 ms |  3000.0000 |  1000.0000 |   45.7 MB |
| 10000 | Tpc      | 4,424.6 ms |  41.83 ms |  34.93 ms | 29000.0000 |  9000.0000 | 371.08 MB |
| 10000 | Tph      | 4,933.7 ms |  46.66 ms |  43.65 ms | 30000.0000 | 10000.0000 | 380.74 MB |
| 10000 | Tpt      | 5,915.6 ms | 112.08 ms | 104.84 ms | 35000.0000 | 11000.0000 | 455.06 MB |