``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Intel Xeon CPU E5-2667 v2 3.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX
  Job-YEDKXI : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX

InvocationCount=1  UnrollFactor=1  

```

## Sparse insert PostgreSQL 14.4

| Size  | Strategy |       Mean |   Error |  StdDev |       Gen0 |       Gen1 | Allocated |
|-------|----------|-----------:|--------:|--------:|-----------:|-----------:|----------:|
| 1000  | Tpc      |   168.0 ms | 0.50 ms | 0.44 ms |  2000.0000 |  1000.0000 |  40.52 MB |
| 1000  | Tph      |   202.0 ms | 0.99 ms | 0.93 ms |  3000.0000 |  1000.0000 |  42.03 MB |
| 1000  | Tpt      |   265.9 ms | 0.55 ms | 0.46 ms |  3000.0000 |  1000.0000 |  48.99 MB |
| 10000 | Tpc      | 1,766.7 ms | 5.35 ms | 4.74 ms | 28000.0000 | 14000.0000 | 392.85 MB |
| 10000 | Tph      | 2,112.2 ms | 4.42 ms | 3.92 ms | 29000.0000 | 15000.0000 | 407.26 MB |
| 10000 | Tpt      | 2,816.2 ms | 8.79 ms | 8.22 ms | 33000.0000 | 15000.0000 | 471.14 MB |