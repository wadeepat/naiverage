using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoadingManager : MonoBehaviour
{
    [Header("Loading Sprites")]
    [SerializeField] private Sprite[] loadingSprites;
    private GameObject LoadingScreen;
    private Slider sliderLoading;
    private TextMeshProUGUI NameShowText;
    private TextMeshProUGUI loadingText;
    private const string LOADING = "loading...";
    // public LoadingScreen instance { get; private set; }
    private string[] SceneShowName = {
        "",
        "Rachne Forest",
        "Naver Town",
        "Calford Castle",
        "Braewood Forest",
        "Cave",
        "Rachne Field",
        "Secret Field",
        ""
    };

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
        // LoadingScreen = GameObject.Find("Canvas").transform.Find("LoadingScreen").gameObject;
        // sliderLoading = LoadingScreen.transform.Find("Slider").GetComponent<Slider>();
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadScene(SceneIndex sceneName)
    {
        LoadingScreen = GameObject.Find("Canvas").transform.Find("LoadingScreen").gameObject;
        sliderLoading = LoadingScreen.transform.Find("Slider").GetComponent<Slider>();
        NameShowText = LoadingScreen.transform.Find("Place").GetComponent<TextMeshProUGUI>();
        loadingText = LoadingScreen.transform.Find("LoadingText").GetComponent<TextMeshProUGUI>();

        LoadingScreen.transform.Find("Background").GetComponent<Image>().overrideSprite = loadingSprites[(int)sceneName];
        NameShowText.text = SceneShowName[(int)sceneName];

        AudioManager.instance.StopAllTrack();
        AudioManager.instance.Play("loading");
        Cursor.visible = false;
        LoadingScreen.SetActive(true);
        // int sceneIndex = (int)(SceneIndex)System.Enum.Parse(typeof(SceneIndex), sceneName);
        StartCoroutine(LoadAsynchronously((int)sceneName));
    }
    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        sliderLoading.value = 0;
        Time.timeScale = 1;
        yield return new WaitForSeconds(2);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        loadingText.text = LOADING;
        loadingText.maxVisibleCharacters = 7;

        while (!operation.isDone)
        {
            sliderLoading.value = operation.progress;
            if (operation.progress >= .9f)
            {
                yield return new WaitForSeconds(1);
                operation.allowSceneActivation = true;
                AudioManager.instance.Stop("loading");
            }
            if (loadingText.maxVisibleCharacters == LOADING.Length) loadingText.maxVisibleCharacters = 7;
            else loadingText.maxVisibleCharacters++;

            yield return new WaitForSeconds(0.06f);
        }
        if (LoadingScreen != null)
        {
            LoadingScreen.SetActive(false);
        }
    }
}
