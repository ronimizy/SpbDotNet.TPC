``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-FNHWWV : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
| Method             | Size  | Factory            |        Mean |     Error |    StdDev |       Gen0 |       Gen1 | Allocated |
|--------------------|-------|--------------------|------------:|----------:|----------:|-----------:|-----------:|----------:|
| BulkEmployeeInsert | 1000  | TpcDatabaseContext |    45.38 ms |  0.572 ms |  0.507 ms |  2000.0000 |          - |  16.41 MB |
| BulkEmployeeInsert | 1000  | TphDatabaseContext |    51.87 ms |  0.988 ms |  0.970 ms |  2000.0000 |          - |  18.59 MB |
| BulkEmployeeInsert | 1000  | TptDatabaseContext |    89.68 ms |  1.713 ms |  4.390 ms |  4000.0000 |  1000.0000 |  31.01 MB |
| BulkEmployeeInsert | 10000 | TpcDatabaseContext |   524.33 ms | 10.448 ms | 29.469 ms | 25000.0000 |  7000.0000 | 162.87 MB |
| BulkEmployeeInsert | 10000 | TphDatabaseContext |   624.22 ms | 12.453 ms | 29.837 ms | 27000.0000 |  8000.0000 | 182.78 MB |
| BulkEmployeeInsert | 10000 | TptDatabaseContext | 1,032.47 ms | 20.327 ms | 47.110 ms | 48000.0000 | 13000.0000 | 310.96 MB |
