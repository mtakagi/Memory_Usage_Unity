using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

 public class test : MonoBehaviour
{
    #if UNITY_IOS && !UNITY_EDITOR
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
        var usage = MemoryUsage.PhysicalUsage();
        memoryUsage.text = $"{usage / (1024 * 1024)}MB";
    }

    public void Malloc()
    {
        #if UNITY_IOS && !UNITY_EDITOR
        allocation();
        #endif
    }

    public void Free() 
    {
        #if UNITY_IOS && !UNITY_EDITOR
        deallocation();
        #endif
    }
}
