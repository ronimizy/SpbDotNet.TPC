``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-HRBODM : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
|                       Method |  Size |            Factory |      Mean |     Error |    StdDev |    Median |  Allocated |
|----------------------------- |------ |------------------- |----------:|----------:|----------:|----------:|-----------:|
|      **GetAllUniformsBenchmark** |  **1000** | **TpcDatabaseContext** |  **4.721 ms** | **0.1468 ms** | **0.4235 ms** |  **4.624 ms** |  **287.07 KB** |
|      GetAllUniformsBenchmark |  1000 | TphDatabaseContext |  4.413 ms | 0.1581 ms | 0.4537 ms |  4.256 ms |  281.26 KB |
|      GetAllUniformsBenchmark |  1000 | TptDatabaseContext |  5.155 ms | 0.1510 ms | 0.4210 ms |  5.030 ms |  281.63 KB |
|      GetAllUniformsBenchmark | 10000 | TpcDatabaseContext | 31.705 ms | 0.6326 ms | 1.5277 ms | 31.777 ms | 2808.18 KB |
|      GetAllUniformsBenchmark | 10000 | TphDatabaseContext | 29.615 ms | 0.5887 ms | 1.3046 ms | 29.710 ms | 2798.69 KB |
|      GetAllUniformsBenchmark | 10000 | TptDatabaseContext | 35.454 ms | 0.6490 ms | 1.3690 ms | 35.325 ms | 2796.99 KB |
| **GetOfficialUniformsBenchmark** |  **1000** | **TpcDatabaseContext** |  **1.906 ms** | **0.0807 ms** | **0.2290 ms** |  **1.844 ms** |  **100.64 KB** |
| GetOfficialUniformsBenchmark |  1000 | TphDatabaseContext |  2.131 ms | 0.0811 ms | 0.2274 ms |  2.133 ms |  103.38 KB |
| GetOfficialUniformsBenchmark |  1000 | TptDatabaseContext |  2.382 ms | 0.0936 ms | 0.2624 ms |  2.344 ms |  102.01 KB |
| GetOfficialUniformsBenchmark | 10000 | TpcDatabaseContext |  9.464 ms | 0.2494 ms | 0.7234 ms |  9.500 ms |  913.93 KB |
| GetOfficialUniformsBenchmark | 10000 | TphDatabaseContext |  9.207 ms | 0.2396 ms | 0.6913 ms |  9.150 ms |  915.13 KB |
| GetOfficialUniformsBenchmark | 10000 | TptDatabaseContext | 11.522 ms | 0.3235 ms | 0.9229 ms | 11.362 ms |  913.83 KB |
