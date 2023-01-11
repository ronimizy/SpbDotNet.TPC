``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-THRHSJ : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
|           Method |            Factory |      Mean |     Error |    StdDev |    Median |
|----------------- |------------------- |----------:|----------:|----------:|----------:|
| **SingleUserInsert** | **TpcDatabaseContext** |  **1.675 ms** | **0.0394 ms** | **0.1110 ms** |  **1.672 ms** |
|   BulkUserInsert | TpcDatabaseContext | 40.669 ms | 0.8123 ms | 1.5844 ms | 40.493 ms |
| **SingleUserInsert** | **TphDatabaseContext** |  **1.791 ms** | **0.0728 ms** | **0.2004 ms** |  **1.773 ms** |
|   BulkUserInsert | TphDatabaseContext | 39.896 ms | 0.6917 ms | 1.2472 ms | 39.572 ms |
| **SingleUserInsert** | **TptDatabaseContext** |  **1.781 ms** | **0.0569 ms** | **0.1633 ms** |  **1.733 ms** |
|   BulkUserInsert | TptDatabaseContext | 48.450 ms | 0.9615 ms | 2.2283 ms | 48.286 ms |
