using UnityEngine;

public static class AndroidMemoryUsage
{

    private static string activityService;

    static AndroidMemoryUsage()
    {
        using (var activityClass = new AndroidJavaClass("android.app.Activity"))
        {
            activityService = activityClass.GetStatic<string>("ACTIVITY_SERVICE");
        }
    }
    public static int MemoryUsage()
    {
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (var manager = activity.Call<AndroidJavaObject>("getSystemService", activityService))
        using (var process = new AndroidJavaClass("android.os.Process"))
        {
            var pid = new int[1] { process.CallStatic<int>("myPid") };
            var memoryInfo = manager.Call<AndroidJavaObject[]>("getProcessMemoryInfo", (object)pid);
            var getTotalPss = memoryInfo[0].Call<int>("getTotalPss");

            memoryInfo[0].Dispose();

            return getTotalPss;
        }
    }
}
