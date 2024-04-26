using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace PdfSharp.Internal;

public static class StringBuilderProvider
{
    private static readonly ObjectPool<StringBuilder> StringBuilderPool =
        new DefaultObjectPoolProvider().CreateStringBuilderPool();

    public static StringBuilderHolder Acquire()
    {
        var builder = StringBuilderPool.Get();
        return new StringBuilderHolder(builder, StringBuilderPool.Return);
    }
}
