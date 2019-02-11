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

    public static InteractiveType GetInteractiveType(string type)
    {
        Assert.Inv(Enum.TryParse("Active", out InteractiveType intType), $"There is no such type: {type}");
        return intType;
    }
}
