using System.Runtime.InteropServices;

public static class MemoryUsage
{
    [DllImport("memory_usage")]
    private static extern long memory_usage();

    public static long PhysicalUsage()
    {
        return memory_usage();
    }
}
