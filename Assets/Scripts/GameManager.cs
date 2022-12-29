using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndex.MainMenu, LoadSceneMode.Additive);
    }
    private void NewGame()
    {
        SceneManager.UnloadSceneAsync((int)SceneIndex.MainMenu);
        SceneManager.LoadSceneAsync((int)SceneIndex.Rachne, LoadSceneMode.Additive);
    }
}
