using System;

public class Utils
{
    public static void DisposeAndSetNull<T>(ref T some) where T : class
    {
        var disposable = some as IDisposable;
        if (disposable != null)
        {
            disposable.Dispose();
            some = null;
        }
    }
}
