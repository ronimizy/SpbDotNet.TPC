``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Unknown processor
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-SKVIAV : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
## Select full hierarchy (Employees)
| Size   | Strategy           |         Mean |      Error |     StdDev |       Gen0 |       Gen1 |    Allocated |
|--------|--------------------|-------------:|-----------:|-----------:|-----------:|-----------:|-------------:|
| 1000   | TpcDatabaseContext |     6.199 ms |  0.1068 ms |  0.0892 ms |          - |          - |    2188.1 KB |
| 1000   | TphDatabaseContext |     5.362 ms |  0.0978 ms |  0.0867 ms |          - |          - |   2177.38 KB |
| 1000   | TptDatabaseContext |     9.243 ms |  0.1387 ms |  0.1297 ms |          - |          - |    3278.7 KB |
| 10000  | TpcDatabaseContext |    64.446 ms |  0.8411 ms |  0.7456 ms |  2000.0000 |          - |  21818.68 KB |
| 10000  | TphDatabaseContext |    64.956 ms |  0.5129 ms |  0.4547 ms |  2000.0000 |          - |  21713.93 KB |
| 10000  | TptDatabaseContext |   107.527 ms |  1.5636 ms |  1.4626 ms |  3000.0000 |          - |  32666.66 KB |
| 100000 | TpcDatabaseContext |   886.714 ms | 13.8826 ms | 12.9858 ms | 25000.0000 |  9000.0000 | 216452.23 KB |
| 100000 | TphDatabaseContext |   830.209 ms |  7.9624 ms |  7.0584 ms | 24000.0000 |  9000.0000 | 215409.34 KB |
| 100000 | TptDatabaseContext | 1,351.630 ms |  6.0282 ms |  5.3439 ms | 37000.0000 | 13000.0000 | 326009.68 KB |

## Select hierarchy slice (Subordinates)    
| Size   | Strategy           |       Mean |     Error |    StdDev |       Gen0 |      Gen1 |    Allocated |
|--------|--------------------|-----------:|----------:|----------:|-----------:|----------:|-------------:|
| 1000   | TpcDatabaseContext |   2.830 ms | 0.0556 ms | 0.0662 ms |          - |         - |   1126.34 KB |
| 1000   | TphDatabaseContext |   2.573 ms | 0.0394 ms | 0.0369 ms |          - |         - |   1118.02 KB |
| 1000   | TptDatabaseContext |   5.309 ms | 0.0905 ms | 0.0803 ms |          - |         - |   2004.35 KB |
| 10000  | TpcDatabaseContext |  26.750 ms | 0.4101 ms | 0.3635 ms |  1000.0000 |         - |   11124.2 KB |
| 10000  | TphDatabaseContext |  26.455 ms | 0.5130 ms | 0.4799 ms |  1000.0000 |         - |  11045.84 KB |
| 10000  | TptDatabaseContext |  56.595 ms | 0.7952 ms | 0.7050 ms |  2000.0000 |         - |  19853.11 KB |
| 100000 | TpcDatabaseContext | 281.489 ms | 4.8938 ms | 6.6986 ms | 12000.0000 | 5000.0000 | 111502.07 KB |
| 100000 | TphDatabaseContext | 283.441 ms | 4.8120 ms | 4.5012 ms | 12000.0000 | 5000.0000 | 110720.59 KB |
| 100000 | TptDatabaseContext | 578.619 ms | 6.0911 ms | 5.3996 ms | 22000.0000 | 7000.0000 | 197982.64 KB |

## Select single hierarchy type (Interns)
| Size   | Strategy           |       Mean |     Error |    StdDev |       Gen0 |      Gen1 |    Allocated |
|--------|--------------------|-----------:|----------:|----------:|-----------:|----------:|-------------:|
| 1000   | TpcDatabaseContext |   1.662 ms | 0.0329 ms | 0.0657 ms |          - |         - |    582.63 KB |
| 1000   | TphDatabaseContext |   1.713 ms | 0.0336 ms | 0.0524 ms |          - |         - |    593.11 KB |
| 1000   | TptDatabaseContext |   3.102 ms | 0.0416 ms | 0.0368 ms |          - |         - |   1129.42 KB |
| 10000  | TpcDatabaseContext |  10.855 ms | 0.1521 ms | 0.1270 ms |          - |         - |   5725.94 KB |
| 10000  | TphDatabaseContext |  11.105 ms | 0.2126 ms | 0.2363 ms |          - |         - |   5830.16 KB |
| 10000  | TptDatabaseContext |  29.662 ms | 0.5854 ms | 0.6264 ms |  1000.0000 |         - |  11164.37 KB |
| 100000 | TpcDatabaseContext | 136.726 ms | 2.4530 ms | 2.1745 ms |  6000.0000 | 3000.0000 |  57374.23 KB |
| 100000 | TphDatabaseContext | 135.878 ms | 2.1584 ms | 1.9134 ms |  6000.0000 | 3000.0000 |  58416.23 KB |
| 100000 | TptDatabaseContext | 301.354 ms | 3.7479 ms | 3.3224 ms | 12000.0000 | 4000.0000 | 111255.02 KB |
