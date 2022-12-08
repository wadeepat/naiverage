using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    // #region  Singleton
    public GameObject player;
    public static PlayerManager instance { get; private set; }
    public string playerLocation { get; private set; }
    void Awake()
    {
        // instance = this;
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Player Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        player = GameObject.FindGameObjectWithTag("Player");
        playerLocation = "Tutorial";
        SceneManager.sceneLoaded += SetPlayer;
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
        //TODO
        // if(playerLocation == "Tutorial")
        // this.playerLocation = data.playerLocation;
    }

    public void SaveData(GameData data)
    {
        data.playerLocation = this.playerLocation;
    }

    // #endregion



}
