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
    public string playerLocation { get; private set; }
    public SerializableDictionary<string, bool> playerEvents;
    public SerializableDictionary<SceneIndex, bool> mapEnable;
    void Awake()
    {
        // instance = this;
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Player Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        else
        {
            playerLocation = "Tutorial";
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        player = GameObject.FindGameObjectWithTag("Player");
        SceneManager.sceneLoaded += SetPlayer;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SetPlayer;
    }
    private void SetPlayer(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void ChangePlayerLocation(string location)
    {
        this.playerLocation = location;
        // Debug.Log("Change to " + this.playerLocation);
    }
    public void LoadData(GameData data)
    {
        Debug.LogWarning("Load from PlayerManager");
        //TODO
        // if(playerLocation == "Tutorial")
        this.playerLocation = data.playerLocation;
        this.mapEnable = data.mapEnable;
        playerEvents = data.tutorialEvents;

    }

    public void SaveData(GameData data)
    {
        data.playerLocation = this.playerLocation;
        data.mapEnable = this.mapEnable;
        data.tutorialEvents = this.playerEvents;
    }
}
