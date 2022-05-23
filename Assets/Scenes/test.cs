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
    
#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern long available_memory();
#endif

    [SerializeField]
    private Text memoryUsage;

    [SerializeField]
    private Text availableMemory;

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
#if UNITY_IOS && !UNITY_EDITOR
        var available = available_memory();
        availableMemory.text = $"{available / (1024 * 1024)}MB";
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
