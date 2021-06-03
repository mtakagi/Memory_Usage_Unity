using UnityEngine;

public class test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var usage = MemoryUsage.PhysicalUsage();
        Debug.Log($"{usage / (1024 * 1024)}MB");
    }
}
