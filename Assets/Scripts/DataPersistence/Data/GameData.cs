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
    public List<Quest> questList;
    public List<Quest> completedQuestList;
    // public Dictionary<string, bool> tutorialEvents;
    //if want to use dictionary use SeriablizableDictionary instead
    public GameData()
    {
        playerPosition = Vector3.zero;
        playerLocation = SceneIndex.Rachne;
        tutorialEvents = new SerializableDictionary<string, bool>{
            {"sataAskToJoin",false},
            {"finishedTutorial",false}
        };
        mapEnable = new SerializableDictionary<SceneIndex, bool>{
            {SceneIndex.Rachne,true},
            {SceneIndex.NaverTown,true},
            {SceneIndex.CalfordCastle,false},
            {SceneIndex.BraewoodForest,false},
            {SceneIndex.Cave,false},
        };
        questList = new List<Quest>();
        completedQuestList = new List<Quest>();
    }
    public override string ToString()
    {
        string temp = "\n";
        temp += $"name: {this.name}\n";
        temp += $"lastUpdate: {this.lastUpdated}\n";
        temp += $"playerLocation: {this.playerLocation.ToString()}\n";
        temp += $"tutorialEvents:\n";
        foreach (var i in tutorialEvents)
        {
            temp += $"\t{i.Key}: {i.Value}\n";
        }
        temp += $"mapEnable:\n";
        foreach (var i in mapEnable)
        {
            temp += $"\t{i.Key}: {i.Value}\n";
        }
        temp += $"questList:\n";
        foreach (var i in questList)
        {
            temp += $"\t{i.questId}: {i.questName}\n";
        }
        temp += $"completedQuest:\n";
        foreach (var i in completedQuestList)
        {
            temp += $"\t{i.questId}: {i.questName}\n";
        }
        return temp;
    }
}
