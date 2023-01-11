``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-FNHWWV : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
|                        Method |  Size |            Factory |      Mean |     Error |    StdDev |    Median |      Gen0 |      Gen1 |   Allocated |
|------------------------------ |------ |------------------- |----------:|----------:|----------:|----------:|----------:|----------:|------------:|
|  **SelectFullHierarchyBenchmark** |  **1000** | **TpcDatabaseContext** |  **5.134 ms** | **0.1026 ms** | **0.2479 ms** |  **5.087 ms** |         **-** |         **-** |  **2383.24 KB** |
|  SelectFullHierarchyBenchmark |  1000 | TphDatabaseContext |  5.268 ms | 0.1040 ms | 0.2054 ms |  5.255 ms |         - |         - |  2380.37 KB |
|  SelectFullHierarchyBenchmark |  1000 | TptDatabaseContext |  7.865 ms | 0.1609 ms | 0.4296 ms |  7.743 ms |         - |         - |  3337.96 KB |
|  SelectFullHierarchyBenchmark | 10000 | TpcDatabaseContext | 52.453 ms | 1.0365 ms | 1.3477 ms | 52.395 ms | 3000.0000 |         - | 23796.56 KB |
|  SelectFullHierarchyBenchmark | 10000 | TphDatabaseContext | 47.863 ms | 0.9527 ms | 1.2388 ms | 47.524 ms | 3000.0000 |         - | 23673.06 KB |
|  SelectFullHierarchyBenchmark | 10000 | TptDatabaseContext | 81.408 ms | 1.5928 ms | 2.7476 ms | 81.045 ms | 5000.0000 | 1000.0000 | 33187.77 KB |
| **SelectHierarchySliceBenchmark** |  **1000** | **TpcDatabaseContext** |  **3.731 ms** | **0.3061 ms** | **0.8430 ms** |  **3.387 ms** |         **-** |         **-** |  **1186.38 KB** |
| SelectHierarchySliceBenchmark |  1000 | TphDatabaseContext |  3.089 ms | 0.0895 ms | 0.2494 ms |  3.038 ms |         - |         - |  1261.97 KB |
| SelectHierarchySliceBenchmark |  1000 | TptDatabaseContext |  4.604 ms | 0.0907 ms | 0.1681 ms |  4.606 ms |         - |         - |  2000.02 KB |
| SelectHierarchySliceBenchmark | 10000 | TpcDatabaseContext | 22.268 ms | 0.4401 ms | 0.3901 ms | 22.363 ms | 1000.0000 |         - | 12292.13 KB |
| SelectHierarchySliceBenchmark | 10000 | TphDatabaseContext | 23.265 ms | 0.4638 ms | 1.1111 ms | 23.105 ms | 1000.0000 |         - | 12234.84 KB |
| SelectHierarchySliceBenchmark | 10000 | TptDatabaseContext | 46.962 ms | 0.9231 ms | 1.5423 ms | 47.243 ms | 3000.0000 | 1000.0000 | 19778.61 KB |
|     **SelectSingleHierarchyType** |  **1000** | **TpcDatabaseContext** |  **2.714 ms** | **0.0859 ms** | **0.2337 ms** |  **2.656 ms** |         **-** |         **-** |   **766.39 KB** |
|     SelectSingleHierarchyType |  1000 | TphDatabaseContext |  2.520 ms | 0.0640 ms | 0.1784 ms |  2.469 ms |         - |         - |   804.23 KB |
|     SelectSingleHierarchyType |  1000 | TptDatabaseContext |  3.116 ms | 0.0779 ms | 0.2170 ms |  3.099 ms |         - |         - |   945.09 KB |
|     SelectSingleHierarchyType | 10000 | TpcDatabaseContext | 17.891 ms | 0.3475 ms | 0.5512 ms | 17.878 ms | 1000.0000 |         - |  7254.95 KB |
|     SelectSingleHierarchyType | 10000 | TphDatabaseContext | 18.465 ms | 0.3687 ms | 0.5404 ms | 18.340 ms | 1000.0000 |         - |  7453.77 KB |
|     SelectSingleHierarchyType | 10000 | TptDatabaseContext | 26.190 ms | 0.5171 ms | 0.9713 ms | 26.412 ms | 1000.0000 |         - |  9289.87 KB |
