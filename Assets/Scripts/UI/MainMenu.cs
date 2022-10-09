using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button[] buttons;
    public GameObject LoadingScreen;
    public Slider sliderLoading;
    private void Start()
    {
        Cursor.visible = true;
        AudioManager.instance.Play("medievalTheme");
        if (!DataPersistenceManager.instance.HasGameData())
        {
            buttons[1].interactable = false;
        }
    }
    public void NewGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.instance.Play("click");
        DisableMenuButton();
        Debug.Log("Click NewGame");

        DataPersistenceManager.instance.NewGame();
        LoadScene("Tutorial");
    }
    public void LoadGame()
    {
        AudioManager.instance.Play("click");
        DisableMenuButton();
        LoadScene("Tutorial");
    }
    public void LoadScene(string sceneName)
    {
        AudioManager.instance.SwapTrack("loading");
        // AudioManager.instance.Stop("medievalTheme");
        // AudioManager.instance.Play("loading");
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
                AudioManager.instance.Stop("loading");
            }
            yield return null;
        }
    }
    private void DisableMenuButton()
    {
        foreach (Button btn in buttons)
        {
            btn.interactable = false;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
