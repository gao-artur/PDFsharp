using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
[CategoriesColumn]
public class PdfFormatterBenchmark
{
    private const int Iterations = 1;
    private const int PropCount = 15;
    private const int RowsCount = 2500;

    public static List<string> Headers { get; private set; } = null!;

    public static List<List<string>> Rows { get; private set; } = null!;

    [GlobalSetup]
    public static void GlobalSetup()
    {
        Headers = Enumerable.Range(1, PropCount)
            .Select(i => $"PropName{i}")
            .ToList();

        Rows = Enumerable.Range(1, RowsCount)
            .Select(rowId => Enumerable.Range(1, PropCount)
                .Select(propId => $"Value{rowId}-{propId}")
                .ToList())
            .ToList();
    }

    [Benchmark]
    public void RenderPdfTable()
    {
        for (var i = 0; i < Iterations; i++)
        {
            _ = PdfFormatter.RenderPdfTable(Headers, Rows);
        }
    }
}