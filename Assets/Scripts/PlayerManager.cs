using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    // #region  Singleton
    public GameObject player { get; private set; }
    public static PlayerManager instance { get; private set; }
    public SceneIndex playerLocation;
    public SerializableDictionary<string, bool> playerEvents;
    public SerializableDictionary<SceneIndex, bool> mapEnable;
    void Awake()
    {
        // if (instance != null)
        // {
        //     Debug.LogWarning("Found more than one Player Manager in the scene. Destroying the newest one.");
        //     Destroy(this.gameObject);
        //     return;
        // }
        // else
        // {
        //     SceneManager.sceneLoaded += PrepareForPlayerManager;
        // }
        // DontDestroyOnLoad(this.gameObject);
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // private void OnDestroy()
    // {
    //     SceneManager.sceneLoaded -= PrepareForPlayerManager;
    // }
    private void PrepareForPlayerManager(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void ChangePlayerLocationToCurrent()
    {
        this.playerLocation = (SceneIndex)SceneManager.GetActiveScene().buildIndex;
        // Debug.Log("Change to " + ((SceneIndex)playerLocation).ToString());
    }
    public void LoadData(GameData data)
    {
        // Debug.Log("Load from PlayerManager");
        this.playerLocation = data.playerLocation;
        // Debug.Log(this.playerLocation);
        this.mapEnable = data.mapEnable;
        playerEvents = data.playerEvents;

    }

    public void SaveData(GameData data)
    {
        data.playerLocation = this.playerLocation;
        data.mapEnable = this.mapEnable;
        data.playerEvents = this.playerEvents;
        // Debug.Log("Save from PlayerManager Location: " + this.playerLocation + " " + data.playerLocation);
    }
}
