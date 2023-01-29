``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Unknown processor
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-DAKRWI : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```

## Sparse insert SQL Server 2019

| Size  | Factory            |       Mean |    Error |   StdDev |       Gen0 |       Gen1 | Allocated |
|-------|--------------------|-----------:|---------:|---------:|-----------:|-----------:|----------:|
| 1000  | TpcDatabaseContext |   331.5 ms |  3.08 ms |  2.73 ms |  4000.0000 |  1000.0000 |  37.28 MB |
| 1000  | TphDatabaseContext |   371.8 ms |  3.42 ms |  3.03 ms |  4000.0000 |  1000.0000 |  38.24 MB |
| 1000  | TptDatabaseContext |   374.7 ms |  3.08 ms |  2.57 ms |  5000.0000 |  1000.0000 |  45.73 MB |
| 10000 | TpcDatabaseContext | 3,052.3 ms | 21.07 ms | 17.59 ms | 46000.0000 | 10000.0000 | 371.34 MB |
| 10000 | TphDatabaseContext | 3,593.2 ms |  9.18 ms |  7.17 ms | 47000.0000 | 12000.0000 |  380.9 MB |
| 10000 | TptDatabaseContext | 4,138.0 ms | 48.70 ms | 43.17 ms | 55000.0000 | 17000.0000 | 455.35 MB |
