using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestLog
{
    private static List<Quest> questList;
    private static List<Quest> completedQuest;

    public delegate void OnQuestChange(List<Quest> activeQuests, List<Quest> completedQuest);
    public static event OnQuestChange onQuestChange;
    public static void Initialize()
    {
        // Debug.Log("new QuestList");
        questList = new List<Quest>();
        completedQuest = new List<Quest>();
    }
    public static bool isQuestNull()
    {
        return questList?.Count > 0;
    }
    public static void LoadQuest(List<Quest> questL, List<Quest> completeL)
    {
        // Initialize();
        // // Debug.Log("quests: ");
        // foreach (Quest q in questL)
        // {
        //     questList.Add(q);
        //     Debug.Log(q.ToString());
        // }
        // // Debug.Log("completed quests: ");
        // foreach (Quest q in completeL)
        // {
        //     completedQuest.Add(q);
        //     Debug.Log(q.ToString());
        // }
        questList = questL;
        completedQuest = completeL;
    }
    public static (List<Quest> q, List<Quest> c) GetAllQuestList()
    {
        return (questList, completedQuest);
    }

    public static void AddQuest(Quest quest)
    {
        AudioManager.instance.Play("click");
        questList.Add(quest);
        // HandleOwnedItems(quest);
        if (quest.addAction != null) quest.addAction();
        onQuestChange.Invoke(questList, completedQuest);

    }

    // public static void CheckQuestObjective(Quest.Objective.Type type, int id)
    // {
    //     foreach (Quest quest in questList)
    //         if (quest.objective.CheckObjectiveCompleted(type, id))
    //             CompleteQuest(quest);
    //     onQuestChange.Invoke(questList, completedQuest);

    // }

    public static void CompleteQuest(Quest quest)
    {
        questList?.Remove(quest);
        completedQuest?.Add(quest);
        if (quest?.compleltedAction != null) quest?.compleltedAction();
        // Inventory.giveGold(quest.goldReward);
        // Character.giveExp(quest.expReward);
        onQuestChange?.Invoke(questList, completedQuest);
    }


    // private static void HandleOwnedItems(Quest quest)
    // {
    //     if (quest.objective.type != Quest.Objective.Type.collect)
    //         return;
    //     int amount = 0;//Inventory.GetCountOfIndex(quest.objective.objectiveId); 
    //     if (quest.objective.ForceAddObjective(amount))
    //     {
    //         CompleteQuest(quest);
    //     }


    // }

    public static Quest getQuestNo(int index)
    {
        // string temp = "";
        // foreach (Quest q in questList)
        // {
        //     temp += q.questId + "\n";
        // }
        // Debug.Log("questList: \n" + temp);
        // temp = "";
        // foreach (Quest q in completedQuest)
        // {
        //     temp += q.questId + "\n";
        // }
        // Debug.Log("completeList: \n" + temp);
        if (index < questList.Count)
            return questList[index];
        else
            return completedQuest[index - questList.Count];
    }

    public static Quest GetQuestById(int id)
    {
        foreach (Quest q in questList)
        {
            if (q.questId == id) return q;
        }
        return null;
    }
    public static void DoQuestProcess()
    {
        foreach (Quest q in questList.ToArray())
        {
            if (q.updateAction != null) q.updateAction();
        }
    }
    public static void DoQuest(Quest.Objective.Type type, int id)
    {

        foreach (Quest quest in questList)
        {
            if (quest.objective.CheckIndexQuest(type, id))
            {
                quest.objective.ForceAddObjective(1);
            }
            if (quest.objective.CheckCompletedQuest(quest))
            {
                CompleteQuest(quest);
                break;
            }
        }
        onQuestChange.Invoke(questList, completedQuest);

    }
    public static int IsThereSomeQuestTalk(NPCIndex idx)
    {
        foreach (Quest q in questList)
        {
            if (q.objective.type == Quest.Objective.Type.talk
            && q.objective.npc == idx)
                return q.questId;
        }
        return -1;
    }
}
