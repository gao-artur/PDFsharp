```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 6.0.29 (6.0.2924.17105), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.29 (6.0.2924.17105), X64 RyuJIT AVX2


```
| Method         | Mean    | Error    | StdDev   | Gen0       | Gen1       | Gen2      | Allocated |
|--------------- |--------:|---------:|---------:|-----------:|-----------:|----------:|----------:|
| RenderPdfTable | 1.273 s | 0.0115 s | 0.0102 s | 43000.0000 | 15000.0000 | 1000.0000 | 520.03 MB |
