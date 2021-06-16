using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class test : MonoBehaviour
{
#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void allocation();

    [DllImport("__Internal")]
    private static extern void deallocation();
#endif

    [SerializeField]
    private Text memoryUsage;

    // Update is called once per frame
    void Update()
    {
#if UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR_OSX
        var usage = MemoryUsage.PhysicalUsage();
        memoryUsage.text = $"{usage / (1024 * 1024)}MB";
#endif
    }

    public void Malloc()
    {
#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
        allocation();
#endif
    }

    public void Free()
    {
#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
        deallocation();
#endif
    }
}
