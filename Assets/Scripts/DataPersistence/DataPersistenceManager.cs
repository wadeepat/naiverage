using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] public bool disableDataPersistence = false;
    // [SerializeField] private bool initializeDataIfNull = false;
    [SerializeField] private bool overrideSelectedProfileId = false;
    [SerializeField] private string testSelectedProfileId = "test";

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public string selectedProfileId { get; private set; } = "";
    private const string saveVariablesKey = "INK_VARIABLES";
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        InitializeSelectedProfiledId();
        //* for testing
        PlayerPrefs.DeleteKey(testSelectedProfileId);

        if (disableDataPersistence)
        {
            Debug.LogWarning("Data Persistence is disabled.");
            if (this.gameData == null)
            {
                // Debug.LogWarning("Game data is nulllllll");
                selectedProfileId = testSelectedProfileId;
                NewGame();
                this.dataPersistenceObjects = FindAllDataPersistenceObjects();
                LoadGame(false);
            }
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        // Debug.LogWarning("OnsceneLoaded");
        LoadGame(false);
    }
    public void OnSceneUnloaded(Scene scene)
    {
        // this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        SaveGame(false);
    }
    public void ChangeSelectedProfileId(string selectedProfileId)
    {
        this.selectedProfileId = selectedProfileId;

        LoadGame(true);
    }
    public void DeleteProfileData(string profileId)
    {
        dataHandler.Delete(profileId);

        InitializeSelectedProfiledId();

        LoadGame(true);
    }
    private void InitializeSelectedProfiledId()
    {
        this.selectedProfileId = dataHandler.GetMostRecentlyUpdateProfileId();

        if (overrideSelectedProfileId)
        {
            this.selectedProfileId = testSelectedProfileId;
            // Debug.LogWarning("Override selected profile id with test id: " + testSelectedProfileId);
        }
    }
    public void NewGame()
    {
        this.gameData = new GameData();
        PlayerPrefs.DeleteKey(saveVariablesKey + selectedProfileId);
        // Debug.Log("gameData new");
        // LoadGame();
    }
    public void LoadGame(bool isLoadFromFile)
    {
        // if (disableDataPersistence) return;
        // Debug.LogWarning("Load game");

        //load any saved data from a data handler
        if (isLoadFromFile)
        {
            this.gameData = dataHandler.Load(selectedProfileId);
            DialogueManager.instance?.LoadDialogue();
        }

        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found. Need to go to NewGame");
            return;
        }

        //push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        //Debug for load data
        // Debug.Log("Game Data Load: " + gameData.ToString());
    }
    public void SaveGame(bool isSaveToFile)
    {
        //if don't have any data to save, log a warning 
        if (this.gameData == null)
        {
            // Debug.LogWarning("No data was found, NewGame is needed");
        }
        //pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        // Debug.Log("Game Data save: " + gameData.ToString());
        //time stamp
        gameData.lastUpdated = System.DateTime.Now.ToBinary();

        //save that data to a file using the data handler
        if (isSaveToFile && !disableDataPersistence) dataHandler.Save(gameData, selectedProfileId);
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    public bool HasGameData()
    {
        return gameData != null;
    }
    public bool HasSomeData()
    {
        Dictionary<string, GameData> profilesGameData = GetAllProfilesGameData();
        foreach (KeyValuePair<string, GameData> data in profilesGameData)
        {
            if (data.Value != null) return true;
        }
        return false;
    }
    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey(testSelectedProfileId);
        DeleteProfileData(testSelectedProfileId);
    }
}
