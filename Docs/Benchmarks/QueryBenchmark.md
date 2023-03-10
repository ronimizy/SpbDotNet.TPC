``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Intel Xeon CPU E5-2667 v2 3.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX
  Job-YEDKXI : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX

InvocationCount=1  UnrollFactor=1  

```

## Select full hierarchy (Employees)
| Size   | Strategy |         Mean |      Error |     StdDev |       Gen0 |       Gen1 |    Allocated |
|--------|----------|-------------:|-----------:|-----------:|-----------:|-----------:|-------------:|
| 1000   | Tpc      |    12.221 ms |  0.0904 ms |  0.0755 ms |          - |          - |   2182.67 KB |
| 1000   | Tph      |    10.994 ms |  0.1293 ms |  0.1209 ms |          - |          - |   2171.73 KB |
| 1000   | Tpt      |    17.827 ms |  0.1432 ms |  0.1339 ms |          - |          - |   3273.05 KB |
| 10000  | Tpc      |   125.475 ms |  1.1854 ms |  1.1088 ms |  1000.0000 |          - |  21814.72 KB |
| 10000  | Tph      |   111.297 ms |  1.3260 ms |  1.2403 ms |  1000.0000 |          - |  21709.97 KB |
| 10000  | Tpt      |   214.081 ms |  3.9879 ms |  6.4397 ms |  2000.0000 |          - |   32662.7 KB |
| 100000 | Tpc      | 1,510.143 ms | 11.5090 ms |  8.9855 ms | 16000.0000 |  8000.0000 | 216411.31 KB |
| 100000 | Tph      | 1,453.715 ms | 25.2127 ms | 21.0538 ms | 15000.0000 |  6000.0000 | 215369.06 KB |
| 100000 | Tpt      | 2,552.307 ms | 50.4044 ms | 58.0457 ms | 23000.0000 | 12000.0000 | 325979.22 KB |


## Select hierarchy slice (Subordinates)    
| Size   | Strategy |         Mean |      Error |     StdDev |       Gen0 |      Gen1 |    Allocated |
|--------|----------|-------------:|-----------:|-----------:|-----------:|----------:|-------------:|
| 1000   | Tpc      |     5.345 ms |  0.0542 ms |  0.0452 ms |          - |         - |   1126.18 KB |
| 1000   | Tph      |     4.828 ms |  0.0679 ms |  0.0602 ms |          - |         - |   1118.02 KB |
| 1000   | Tpt      |     9.975 ms |  0.1121 ms |  0.0994 ms |          - |         - |   2004.07 KB |
| 10000  | Tpc      |    41.257 ms |  0.3943 ms |  0.3688 ms |          - |         - |   11124.2 KB |
| 10000  | Tph      |    41.019 ms |  0.2751 ms |  0.2438 ms |          - |         - |  11045.84 KB |
| 10000  | Tpt      |    98.131 ms |  0.9501 ms |  0.8423 ms |  1000.0000 |         - |  19853.11 KB |
| 100000 | Tpc      |   529.300 ms |  9.8678 ms | 10.1335 ms |  8000.0000 | 5000.0000 | 111502.97 KB |
| 100000 | Tph      |   489.487 ms |  9.6311 ms | 12.5231 ms |  8000.0000 | 3000.0000 | 110720.88 KB |
| 100000 | Tpt      | 1,085.802 ms | 19.1862 ms | 17.9467 ms | 14000.0000 | 7000.0000 | 197984.06 KB |


## Select single hierarchy type (Interns)
| Size   | Strategy |       Mean |     Error |    StdDev |      Gen0 |      Gen1 |    Allocated |
|--------|----------|-----------:|----------:|----------:|----------:|----------:|-------------:|
| 1000   | Tpc      |   2.823 ms | 0.0560 ms | 0.0524 ms |         - |         - |    582.63 KB |
| 1000   | Tph      |   2.888 ms | 0.0430 ms | 0.0381 ms |         - |         - |    593.11 KB |
| 1000   | Tpt      |   5.617 ms | 0.0828 ms | 0.0734 ms |         - |         - |   1129.42 KB |
| 10000  | Tpc      |  19.336 ms | 0.2152 ms | 0.1908 ms |         - |         - |   5725.94 KB |
| 10000  | Tph      |  20.893 ms | 0.1497 ms | 0.1401 ms |         - |         - |   5830.16 KB |
| 10000  | Tpt      |  45.978 ms | 0.2481 ms | 0.2200 ms |         - |         - |  11164.37 KB |
| 100000 | Tpc      | 255.946 ms | 4.7226 ms | 4.1865 ms | 4000.0000 | 3000.0000 |  57373.95 KB |
| 100000 | Tph      | 276.843 ms | 5.3888 ms | 5.5339 ms | 4000.0000 | 3000.0000 |   58415.4 KB |
| 100000 | Tpt      | 538.376 ms | 3.7686 ms | 3.3407 ms | 8000.0000 | 5000.0000 | 111255.02 KB |

