using UnityEngine;
using System.Collections;

public class csDestroyEffectVer2 : MonoBehaviour
{
    private float time = 1.5f;
    void Start()
    {
        Destroy(gameObject, time);
    }
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C))
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
