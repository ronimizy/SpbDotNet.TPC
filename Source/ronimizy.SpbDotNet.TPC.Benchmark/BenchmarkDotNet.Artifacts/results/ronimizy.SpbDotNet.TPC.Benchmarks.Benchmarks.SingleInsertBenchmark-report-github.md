``` ini

BenchmarkDotNet=v0.13.3, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD
  Job-QORJXR : .NET 7.0.1 (7.0.122.56804), Arm64 RyuJIT AdvSIMD

InvocationCount=1  UnrollFactor=1  

```
|           Method |            Factory |     Mean |     Error |    StdDev | Allocated |
|----------------- |------------------- |---------:|----------:|----------:|----------:|
| SingleUserInsert | TpcDatabaseContext | 1.536 ms | 0.0468 ms | 0.1329 ms |  40.42 KB |
| SingleUserInsert | TphDatabaseContext | 1.632 ms | 0.0536 ms | 0.1555 ms |   38.2 KB |
| SingleUserInsert | TptDatabaseContext | 1.574 ms | 0.0418 ms | 0.1200 ms |  39.49 KB |
