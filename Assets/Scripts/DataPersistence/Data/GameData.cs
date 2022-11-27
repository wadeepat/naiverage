using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string name;
    public long lastUpdated;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> tutorialEvents;
    // public Dictionary<string, bool> tutorialEvents;
    //if want to use dictionary use SeriablizableDictionary instead
    public GameData()
    {
        playerPosition = Vector3.zero;
        tutorialEvents = new SerializableDictionary<string, bool>{
            {"sataAskToJoin",false}
        };
    }
}
