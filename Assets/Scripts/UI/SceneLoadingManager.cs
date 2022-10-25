using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject LoadingScreen;
    public Slider sliderLoading;
    // public LoadingScreen instance { get; private set; }

    public static SceneLoadingManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            // Debug.Log("Found more than one SceneLoadingManager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        // DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string sceneName)
    {
        AudioManager.instance.StopAllTrack();
        AudioManager.instance.Play("loading");
        Cursor.visible = false;
        LoadingScreen.SetActive(true);
        int sceneIndex = (int)(SceneIndex)System.Enum.Parse(typeof(SceneIndex), sceneName);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        sliderLoading.value = 0;
        Time.timeScale = 1;
        yield return new WaitForSeconds(2);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            sliderLoading.value = operation.progress;
            if (operation.progress >= .9f)
            {
                yield return new WaitForSeconds(1);
                operation.allowSceneActivation = true;
                AudioManager.instance.Stop("loading");
            }
            yield return null;
        }
    }
}
