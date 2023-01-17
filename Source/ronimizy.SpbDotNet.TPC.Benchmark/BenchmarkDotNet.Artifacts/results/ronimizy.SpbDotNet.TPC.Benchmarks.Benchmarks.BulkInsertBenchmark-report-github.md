``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Unknown processor
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-SKVIAV : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|             Method |  Size |            Factory |        Mean |    Error |   StdDev |       Gen0 |       Gen1 | Allocated |
|------------------- |------ |------------------- |------------:|---------:|---------:|-----------:|-----------:|----------:|
| BulkEmployeeInsert |  1000 | TpcDatabaseContext |    81.33 ms | 1.056 ms | 0.936 ms |  1000.0000 |          - |  15.49 MB |
| BulkEmployeeInsert |  1000 | TphDatabaseContext |    85.00 ms | 1.072 ms | 1.003 ms |  1000.0000 |          - |  17.13 MB |
| BulkEmployeeInsert |  1000 | TptDatabaseContext |   150.84 ms | 1.278 ms | 1.196 ms |  3000.0000 |          - |  30.76 MB |
| BulkEmployeeInsert | 10000 | TpcDatabaseContext |   828.78 ms | 4.468 ms | 3.961 ms | 17000.0000 |  5000.0000 | 153.14 MB |
| BulkEmployeeInsert | 10000 | TphDatabaseContext |   918.49 ms | 3.091 ms | 2.581 ms | 19000.0000 |  7000.0000 | 170.52 MB |
| BulkEmployeeInsert | 10000 | TptDatabaseContext | 1,621.78 ms | 5.142 ms | 4.558 ms | 35000.0000 | 11000.0000 | 304.71 MB |
