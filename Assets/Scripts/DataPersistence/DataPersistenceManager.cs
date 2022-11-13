using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] public bool disableDataPersistence = false;
    [SerializeField] private bool initializeDataIfNull = false;
    [SerializeField] private bool overrideSelectedProfileId = false;
    [SerializeField] private string testSelectedProfileId = "test";

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public string selectedProfileId { get; private set; } = "";
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        if (disableDataPersistence)
        {
            Debug.LogWarning("Data Persistence is disabled.");
        }

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        InitializeSelectedProfiledId();
        PlayerPrefs.DeleteKey(testSelectedProfileId);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        // SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        // SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void ChangeSelectedProfileId(string selectedProfileId)
    {
        this.selectedProfileId = selectedProfileId;

        LoadGame();
    }
    public void DeleteProfileData(string profileId)
    {
        dataHandler.Delete(profileId);

        InitializeSelectedProfiledId();

        LoadGame();
    }
    private void InitializeSelectedProfiledId()
    {
        this.selectedProfileId = dataHandler.GetMostRecentlyUpdateProfileId();

        if (overrideSelectedProfileId)
        {
            this.selectedProfileId = testSelectedProfileId;
            Debug.LogWarning("Override selected profile id with test id: " + testSelectedProfileId);
        }
    }
    public void NewGame()
    {
        this.gameData = new GameData();
        Debug.Log("gameData new");
    }
    public void LoadGame()
    {
        // if (disableDataPersistence) return;

        //load any saved data from a data handler
        this.gameData = dataHandler.Load(selectedProfileId);

        if (initializeDataIfNull)
        {
            NewGame();
        }
        //if no data can be loaded, initialize to a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Need to go to NewGame");
            return;
        }

        //push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

    }
    public void SaveGame()
    {
        if (disableDataPersistence) return;
        //if don't have any data to save, log a warning 
        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found, NewGame is needed");
        }
        //pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        //time stamp
        gameData.lastUpdated = System.DateTime.Now.ToBinary();
        // Debug.Log("Saved finished turtorial = " + gameData.finishedTutorial);

        //save that data to a file using the data handler
        dataHandler.Save(gameData, selectedProfileId);
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    public bool HasGameData()
    {
        return gameData != null;
    }
    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
}
