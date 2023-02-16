``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 10 (10.0.19044.2486/21H2/November2021Update)
Intel Xeon CPU E5-2667 v2 3.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX
  Job-YEDKXI : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX

InvocationCount=1  UnrollFactor=1  

```

| Strategy |     Mean |     Error |    StdDev |   Median | Allocated |
|----------|---------:|----------:|----------:|---------:|----------:|
| Tpc      | 2.920 ms | 0.0577 ms | 0.1336 ms | 2.875 ms |  808.9 KB |
| Tph      | 2.849 ms | 0.0640 ms | 0.1838 ms | 2.767 ms | 808.54 KB |
| Tpt      | 3.005 ms | 0.0597 ms | 0.1178 ms | 2.964 ms | 808.54 KB |
