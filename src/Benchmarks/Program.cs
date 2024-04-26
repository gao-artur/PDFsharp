using BenchmarkDotNet.Running;

namespace Benchmarks;

internal class Program
{
    public static void Main(string[] args)
    {
        // var summary = BenchmarkRunner.Run<PdfFormatterBenchmark>();
        CreatePdf();
    }

    private static void CreatePdf()
    {
        Console.WriteLine("Starting...");
        PdfFormatterBenchmark.GlobalSetup();
        Thread.Sleep(5_000);
        Console.WriteLine("Started");

        var renderer = PdfFormatter.RenderPdfTable(
            PdfFormatterBenchmark.Headers,
            PdfFormatterBenchmark.Rows);

        //renderer.Save(@"c:\\temp\test.pdf");

        Console.WriteLine("Done!");
        // Thread.Sleep(250_000_000);
    }
}