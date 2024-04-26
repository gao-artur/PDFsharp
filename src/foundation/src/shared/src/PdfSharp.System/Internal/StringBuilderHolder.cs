using System.Text;

namespace PdfSharp.Internal;

public readonly struct StringBuilderHolder : IDisposable
{
    private readonly Action<StringBuilder> onDispose;

    public StringBuilder StringBuilder { get; }

    public StringBuilderHolder(StringBuilder stringBuilder, Action<StringBuilder> onDispose)
    {
        this.onDispose = onDispose;
        StringBuilder = stringBuilder;
    }

    public void Dispose()
    {
        onDispose(StringBuilder);
    }
}
