using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string name;
    public long lastUpdated;
    public SceneIndex playerLocation;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> tutorialEvents;
    public SerializableDictionary<SceneIndex, bool> mapEnable;
    // public Dictionary<string, bool> tutorialEvents;
    //if want to use dictionary use SeriablizableDictionary instead
    public GameData()
    {
        playerPosition = Vector3.zero;
        playerLocation = SceneIndex.Tutorial;
        tutorialEvents = new SerializableDictionary<string, bool>{
            {"sataAskToJoin",false},
            {"finishedTutorial",false}
        };
        mapEnable = new SerializableDictionary<SceneIndex, bool>{
            {SceneIndex.Tutorial,true},
            {SceneIndex.NaverTown,false},
            {SceneIndex.CalfordCastle,false},
            {SceneIndex.BraewoodForest,false},
            {SceneIndex.Cave,false},
        };
    }
}
