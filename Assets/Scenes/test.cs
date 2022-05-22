using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class test : MonoBehaviour
{
#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
    [DllImport("__Internal")]
#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    [DllImport("allocation")]
#endif
    private static extern void allocation();

#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
    [DllImport("__Internal")]
#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    [DllImport("allocation")]
#endif
    private static extern void deallocation();

    [SerializeField]
    private Text memoryUsage;

    // Update is called once per frame
    void Update()
    {
#if UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        try
        {
            var usage = MemoryUsage.PhysicalUsage();
            memoryUsage.text = $"{usage / (1024 * 1024)}MB";
        }
        catch (Exception e)
        {
            memoryUsage.text = e.Message;
        }
#endif
    }

    public void Malloc()
    {
#if UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        allocation();
#endif
    }

    public void Free()
    {
#if UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX 
        deallocation();
#endif
    }
}
