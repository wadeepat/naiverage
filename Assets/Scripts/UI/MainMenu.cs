using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider sliderLoading;
    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        Debug.Log("play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        Cursor.visible = false;
        int sceneIndex = (int)(SceneIndex)System.Enum.Parse(typeof(SceneIndex), sceneName);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        sliderLoading.value = 0;
        LoadingScreen.SetActive(true);
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
            }
            yield return null;
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
