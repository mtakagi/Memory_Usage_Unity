using System.Runtime.InteropServices;

public static class MemoryUsage
{
    #if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    #else
    [DllImport("memory_usage")]
    #endif
    private static extern long memory_usage();

    public static long PhysicalUsage()
    {
        return memory_usage();
    }
}
