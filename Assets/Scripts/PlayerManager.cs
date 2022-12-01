using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    // #region  Singleton
    public GameObject player;
    public static PlayerManager instance;
    public string playerLocation { get; private set; }
    void Awake()
    {
        instance = this;
    }
    public void ChangePlayerLocation(string location)
    {
        this.playerLocation = location;
    }
    public void LoadData(GameData data)
    {
        this.playerLocation = data.playerLocation;
    }

    public void SaveData(GameData data)
    {
        data.playerLocation = this.playerLocation;
    }

    // #endregion



}
