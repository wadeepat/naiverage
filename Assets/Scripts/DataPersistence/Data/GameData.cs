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
    public SerializableDictionary<string, bool> playerEvents;
    public SerializableDictionary<SceneIndex, bool> mapEnable;
    public List<int> questIdxList;
    public List<int> completedQuestIdxList;
    // public Dictionary<string, bool> tutorialEvents;
    //if want to use dictionary use SeriablizableDictionary instead
    public GameData()
    {
        playerPosition = Vector3.zero;
        playerLocation = SceneIndex.Rachne;
        playerEvents = new SerializableDictionary<string, bool>{
            {"sataAskToJoin",false},
            {"finishedTutorial",false},
            // {"metAaron",false}
        };
        mapEnable = new SerializableDictionary<SceneIndex, bool>{
            {SceneIndex.Rachne,true},
            {SceneIndex.NaverTown,false},
            {SceneIndex.CalfordCastle,false},
            {SceneIndex.BraewoodForest,false},
            {SceneIndex.Cave,false},
        };
        questIdxList = new List<int>();
        completedQuestIdxList = new List<int>();
    }
    public override string ToString()
    {
        string temp = "\n";
        temp += $"name: {this.name}\n";
        temp += $"lastUpdate: {this.lastUpdated}\n";
        temp += $"playerLocation: {this.playerLocation.ToString()}\n";
        temp += $"tutorialEvents:\n";
        foreach (var i in playerEvents)
        {
            temp += $"\t{i.Key}: {i.Value}\n";
        }
        temp += $"mapEnable:\n";
        foreach (var i in mapEnable)
        {
            temp += $"\t{i.Key}: {i.Value}\n";
        }
        temp += $"questList:\n";
        foreach (var i in questIdxList)
        {
            temp += $"\tid: {i}\n";
        }
        temp += $"completedQuest:\n";
        foreach (var i in completedQuestIdxList)
        {
            temp += $"\tid: {i}\n";
        }
        return temp;
    }
}
