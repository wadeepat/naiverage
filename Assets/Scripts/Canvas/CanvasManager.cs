using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            // Debug.LogWarning("Found more than one CasvasManager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        // if (SceneManager.GetActiveScene().buildIndex != 0)
        DontDestroyOnLoad(this.gameObject);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += DestroySelf;
    }

    // called second
    void DestroySelf(Scene scene, LoadSceneMode mode)
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeSceneIndex == (int)SceneIndex.MainMenu)
            Destroy(this.gameObject);
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= DestroySelf;
    }
    public GameObject GetCanvasObject(string name)
    {
        return transform.Find(name).gameObject;
    }
}
