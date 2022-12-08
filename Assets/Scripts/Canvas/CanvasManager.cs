using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Player Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public GameObject GetCanvasObject(string name)
    {
        return transform.Find(name).gameObject;
    }
}
