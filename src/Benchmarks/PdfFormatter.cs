using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;

namespace Benchmarks;

public static class PdfFormatter
{
    private const string Font = "Arial";

    static PdfFormatter()
    {
        GlobalFontSettings.FontResolver = new FailsafeFontResolver();
    }

    public static PdfDocumentRenderer RenderPdfTable(List<string> headers, List<List<string>> rows)
    {
        var document = new Document();
        InitStyles(document);

        var table = InitializeTable(document, headers.Count);
        WriteDataToTable(table, headers, rows);

        var renderer = new PdfDocumentRenderer { Document = document };
        renderer.RenderDocument();
        return renderer;
    }

    private static void WriteDataToTable(
        Table table,
        List<string> headers,
        List<List<string>> rows)
    {
        // set headers
        AddRow(table, headers);

        // set row values
        foreach (var row in rows)
        {
            AddRow(table, row);
        }
    }

    private static void AddRow(Table table, List<string> values)
    {
        var index = 0;
        var row = table.AddRow();
        foreach (var value in values)
        {
            row[index++].AddParagraph(value);
        }
    }

    private static void InitStyles(Document document)
    {
        var pageSetup = document.DefaultPageSetup.Clone();
        pageSetup.PageFormat = PageFormat.A4;
        pageSetup.Orientation = Orientation.Landscape;
        pageSetup.TopMargin = Unit.FromMillimeter(10);
        pageSetup.StartingNumber = 1;

        var section = document.AddSection();
        section.PageSetup = pageSetup;

        // Inner table data font style.
        var style = document.Styles["Normal"]!;
        style.Font.Name = Font;
        style.Font.Size = 4;
        style.Font.Bold = false;
        style.ParagraphFormat.KeepWithNext = false;
        style.ParagraphFormat.SpaceBefore = 0;
        style.ParagraphFormat.SpaceAfter = 0;
    }

    private static Table InitializeTable(Document document, int columnsCount)
    {
        var table = document.LastSection.AddTable();
        table.Style = "Normal";
        table.Borders.Visible = true;
        table.Columns.Width = GetColumnWidth(document.DefaultPageSetup, columnsCount);

        for (var i = 0; i < columnsCount; i++)
        {
            var column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Left;
        }

        return table;
    }

    private static Unit GetColumnWidth(PageSetup pageSetup, int headersCount)
    {
        return (pageSetup.PageHeight - pageSetup.LeftMargin - pageSetup.RightMargin) / headersCount;
    }
}