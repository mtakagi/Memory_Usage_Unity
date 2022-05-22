using System.Runtime.InteropServices;

public static class MemoryUsage
{
#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern long memory_usage();
#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    [DllImport("memory_usage")]
    private static extern long memory_usage();
#endif

    public static long PhysicalUsage()
    {
#if UNITY_IOS || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        return memory_usage();
#elif UNITY_ANDROID && !UNITY_EDITOR
        return AndroidMemoryUsage.MemoryUsage() * 1024;
#else
        throw new System.Exception();
#endif
    }
}