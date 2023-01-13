``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-EPUQRV : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
|             Method |  Size |            Factory |      Mean |     Error |    StdDev |       Gen0 |       Gen1 | Allocated |
|------------------- |------ |------------------- |----------:|----------:|----------:|-----------:|-----------:|----------:|
| BulkEmployeeInsert |  1000 | TpcDatabaseContext |  45.41 ms |  0.830 ms |  0.776 ms |  2000.0000 |          - |  15.47 MB |
| BulkEmployeeInsert |  1000 | TphDatabaseContext |  48.01 ms |  0.788 ms |  0.658 ms |  2000.0000 |          - |  17.15 MB |
| BulkEmployeeInsert |  1000 | TptDatabaseContext |  83.62 ms |  1.061 ms |  0.940 ms |  4000.0000 |  1000.0000 |  30.68 MB |
| BulkEmployeeInsert | 10000 | TpcDatabaseContext | 491.84 ms |  9.673 ms | 13.241 ms | 23000.0000 |  5000.0000 | 153.08 MB |
| BulkEmployeeInsert | 10000 | TphDatabaseContext | 541.15 ms |  9.379 ms |  8.773 ms | 25000.0000 |  8000.0000 | 170.46 MB |
| BulkEmployeeInsert | 10000 | TptDatabaseContext | 921.13 ms | 15.267 ms | 13.534 ms | 47000.0000 | 13000.0000 | 304.43 MB |
