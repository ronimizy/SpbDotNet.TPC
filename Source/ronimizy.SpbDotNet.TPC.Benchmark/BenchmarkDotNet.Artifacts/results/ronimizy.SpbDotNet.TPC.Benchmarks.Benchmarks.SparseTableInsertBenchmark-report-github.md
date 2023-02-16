``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-IAJVOI : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
|                       Method |  Size |            Factory |      Mean |     Error |    StdDev |       Gen0 |       Gen1 |      Gen2 | Allocated |
|----------------------------- |------ |------------------- |----------:|----------:|----------:|-----------:|-----------:|----------:|----------:|
| AddEmployeeUniformsBenchmark |  1000 | TpcDatabaseContext |  61.23 ms |  1.054 ms |  1.609 ms |  6000.0000 |  2000.0000 |         - |  40.45 MB |
| AddEmployeeUniformsBenchmark |  1000 | TphDatabaseContext |  72.83 ms |  1.431 ms |  1.911 ms |  6000.0000 |  2000.0000 |         - |  41.97 MB |
| AddEmployeeUniformsBenchmark |  1000 | TptDatabaseContext |  87.67 ms |  1.005 ms |  0.839 ms |  7000.0000 |  1000.0000 |         - |  48.94 MB |
| AddEmployeeUniformsBenchmark | 10000 | TpcDatabaseContext | 708.73 ms | 13.706 ms | 12.821 ms | 61000.0000 | 22000.0000 | 2000.0000 | 392.76 MB |
| AddEmployeeUniformsBenchmark | 10000 | TphDatabaseContext | 862.59 ms | 16.714 ms | 16.415 ms | 63000.0000 | 21000.0000 | 2000.0000 | 407.39 MB |
| AddEmployeeUniformsBenchmark | 10000 | TptDatabaseContext | 996.48 ms | 16.592 ms | 15.521 ms | 71000.0000 | 22000.0000 | 1000.0000 | 470.87 MB |
