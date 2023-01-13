``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-QORJXR : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
|             Method |  Size |            Factory |      Mean |     Error |    StdDev |       Gen0 |       Gen1 | Allocated |
|------------------- |------ |------------------- |----------:|----------:|----------:|-----------:|-----------:|----------:|
| BulkEmployeeInsert |  1000 | TpcDatabaseContext |  44.93 ms |  0.841 ms |  0.746 ms |  2000.0000 |          - |  15.47 MB |
| BulkEmployeeInsert |  1000 | TphDatabaseContext |  47.94 ms |  0.776 ms |  0.726 ms |  2000.0000 |          - |  17.15 MB |
| BulkEmployeeInsert |  1000 | TptDatabaseContext |  84.64 ms |  1.512 ms |  1.262 ms |  4000.0000 |  1000.0000 |  30.68 MB |
| BulkEmployeeInsert | 10000 | TpcDatabaseContext | 488.95 ms |  5.590 ms |  5.229 ms | 23000.0000 |  5000.0000 | 153.08 MB |
| BulkEmployeeInsert | 10000 | TphDatabaseContext | 542.67 ms | 10.741 ms | 10.549 ms | 25000.0000 |  8000.0000 | 170.46 MB |
| BulkEmployeeInsert | 10000 | TptDatabaseContext | 986.67 ms | 18.656 ms | 15.579 ms | 47000.0000 | 13000.0000 | 304.43 MB |
