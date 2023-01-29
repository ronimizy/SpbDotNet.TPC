``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Unknown processor
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-MDMPRP : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
## Sparse query full hierarchy SQL Server 2019

| Size  | Factory            |      Mean |     Error |    StdDev |      Gen0 |   Allocated |
|-------|--------------------|----------:|----------:|----------:|----------:|------------:|
| 1000  | TpcDatabaseContext |  8.171 ms | 0.1615 ms | 0.1728 ms |         - |  1514.31 KB |
| 1000  | TphDatabaseContext |  6.422 ms | 0.1238 ms | 0.1521 ms |         - |  1393.21 KB |
| 1000  | TptDatabaseContext | 11.182 ms | 0.1318 ms | 0.1169 ms |         - |  1512.57 KB |
| 10000 | TpcDatabaseContext | 59.582 ms | 0.7436 ms | 0.6956 ms | 1000.0000 |  14997.4 KB |
| 10000 | TphDatabaseContext | 56.029 ms | 0.7086 ms | 0.6628 ms | 1000.0000 | 13864.45 KB |
| 10000 | TptDatabaseContext | 65.697 ms | 0.8209 ms | 0.7678 ms | 1000.0000 | 14996.85 KB |

## Sparse query single type SQL Server 2019

| Size  | Factory            |      Mean |     Error |    StdDev | Gen0 |  Allocated |
|-------|--------------------|----------:|----------:|----------:|-----:|-----------:|
| 1000  | TpcDatabaseContext |  2.780 ms | 0.0605 ms | 0.1784 ms |    - |  554.91 KB |
| 1000  | TphDatabaseContext |  4.302 ms | 0.0851 ms | 0.1513 ms |    - |  522.75 KB |
| 1000  | TptDatabaseContext |  4.737 ms | 0.0934 ms | 0.1799 ms |    - |  555.91 KB |
| 10000 | TpcDatabaseContext | 14.237 ms | 0.2822 ms | 0.4868 ms |    - | 5424.34 KB |
| 10000 | TphDatabaseContext | 18.703 ms | 0.3638 ms | 0.4044 ms |    - | 5066.23 KB |
| 10000 | TptDatabaseContext | 17.645 ms | 0.3476 ms | 0.6357 ms |    - |  5459.7 KB |