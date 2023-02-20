using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public string name;
    public string saveName;
    public long lastUpdated;
    public SceneIndex playerLocation;
    public int playerPath;
    public SerializableDictionary<string, bool> playerEvents;
    public SerializableDictionary<SceneIndex, bool> mapEnable;
    public List<int> questIdxList;
    public List<int> completedQuestIdxList;
    public List<Item> inventoryItem;
    public List<Potion> inventoryPotion;
    public List<Item> questsInventory;
    public List<SkillBook> skillBooks;
    public List<Skill> skill;
    public int[] stackItem;
    public int[] stackPotion;
    public int[] stackQuests;
    public int[] slotP;
    public int[] slotS;
    // public Dictionary<string, bool> tutorialEvents;
    //if want to use dictionary use SeriablizableDictionary instead
    public GameData()
    {
        saveName = "untitle";
        playerLocation = SceneIndex.Rachne;
        playerPath = 0;
        playerEvents = new SerializableDictionary<string, bool>{
            {"sataAskToJoin",false},
            {"finishedTutorial",false},
            {"backToPast",false},
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
        inventoryItem = new List<Item>(new Item[28]);
        stackItem = new int[28];
        inventoryPotion = new List<Potion>(new Potion[16]);
        stackPotion = new int[16];
        slotP = new int[4] { -1, -1, -1, -1 };
        questsInventory = new List<Item>(new Item[8]);
        stackQuests = new int[8];
        skill = new List<Skill>(new Skill[12]);
        slotS = new int[3] { -1, -1, -1 };

    }
    public override string ToString()
    {
        string temp = "\n";
        temp += $"name: {this.name}\n";
        temp += $"lastUpdate: {this.lastUpdated}\n";
        temp += $"playerPath: {this.playerPath}\n";
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
        //Inventory 
        temp += $"inventoryItem:\n";
        foreach (var i in inventoryItem)
        {
            temp += $"\tinven: {i}\n";
        }
        temp += $"stackItem:\n";
        foreach (var i in stackItem)
        {
            temp += $"\tstack: {i}\n";
        }
        //Potion
        temp += $"inventoryPotion:\n";
        foreach (var i in inventoryPotion)
        {
            temp += $"\tinvenP: {i}\n";
        }
        temp += $"stackPotion:\n";
        foreach (var i in stackPotion)
        {
            temp += $"\tstackP: {i}\n";
        }
        temp += $"slotP:\n";
        foreach (var i in slotP)
        {
            temp += $"\tslotP: {i}\n";
        }
        // Quests
        temp += $"questsInventory:\n";
        foreach (var i in questsInventory)
        {
            temp += $"\tinvenQ: {i.name}\n";
        }
        temp += $"stackQuests:\n";
        foreach (var i in stackQuests)
        {
            temp += $"\tstackQ: {i}\n";
        }
        // SkillBook
        temp += $"skillBooks:\n";
        foreach (var i in skillBooks)
        {
            temp += $"\tinvenSK: {i}\n";
        }
        //Skill
        temp += $"skill:\n";
        foreach (var i in skill)
        {
            temp += $"\tinvenS: {i}\n";
        }
        temp += $"slotS:\n";
        foreach (var i in slotS)
        {
            temp += $"\tslotS: {i}\n";
        }
        return temp;

    }
}
