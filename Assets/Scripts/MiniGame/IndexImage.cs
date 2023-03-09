using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexImage : MonoBehaviour
{   
    private Camera cam;
    void start(){
        Canvas canvas = gameObject.GetComponent<Canvas>() ?? null;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canvas.worldCamera = cam;
    }
}
