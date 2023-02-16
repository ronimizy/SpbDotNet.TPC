``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Unknown processor
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-SKVIAV : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|           Method |            Factory |     Mean |     Error |    StdDev | Allocated |
|----------------- |------------------- |---------:|----------:|----------:|----------:|
| SingleUserInsert | TpcDatabaseContext | 1.401 ms | 0.0379 ms | 0.1087 ms |  38.59 KB |
| SingleUserInsert | TphDatabaseContext | 1.321 ms | 0.0401 ms | 0.1162 ms |  38.23 KB |
| SingleUserInsert | TptDatabaseContext | 1.468 ms | 0.0475 ms | 0.1370 ms |  38.23 KB |
