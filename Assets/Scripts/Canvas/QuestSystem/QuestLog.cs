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
        questList = new List<Quest>();
        completedQuest = new List<Quest>();
    }
    public static bool isQuestNull()
    {
        return questList?.Count > 0;
    }
    public static void LoadQuest(List<int> questIdxL, List<int> completeIdxL)
    {
        Initialize();
        foreach (int i in questIdxL)
        {
            questList.Add(Database.questList[i]);
        }
        foreach (int i in completeIdxL)
        {
            completedQuest.Add(Database.questList[i]);
        }
        onQuestChange?.Invoke(questList, completedQuest);
    }
    public static (List<int> q, List<int> c) GetAllQuestList()
    {
        List<int> qIdx = new List<int>();
        List<int> cIdx = new List<int>();
        foreach (Quest quest in questList)
        {
            qIdx.Add(quest.questId);
        }
        foreach (Quest quest in completedQuest)
        {
            cIdx.Add(quest.questId);
        }
        return (qIdx, cIdx);
    }

    public static void AddQuest(Quest quest)
    {
        // Debug.Log($"<color=#FFA>Add quest: {quest.questId}</color>");
        AudioManager.instance.Play("addQuest");
        quest.objective.currentAmount = 0;
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
        // Debug.Log($"<color=#AEF>Complete quest: {quest.questId}</color>");
        // AudioManager.instance.Play("completeQuest");
        // if (quest.objective.dialogue is not null) DialogueManager.instance.EnterDialogueMode(quest.objective.dialogue);
        if (quest.objective.dialogue != null) DialogueManager.instance.EnterDialogueMode(quest.objective.dialogue);
        questList.Remove(quest);
        completedQuest.Add(quest);
        if (quest.compleltedAction != null) quest.compleltedAction();
        MagicPearls.GetPearl(quest.MPReward);
        onQuestChange.Invoke(questList, completedQuest);
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

    public static Quest GetActiveQuestById(int id)
    {
        foreach (Quest q in questList)
        {
            if (q.questId == id) return q;
        }
        return null;
    }
    public static Quest GetCompleteQuestById(int id)
    {
        foreach (Quest q in completedQuest)
        {
            if (q.questId == id) return q;
        }
        return null;
    }
    public static void DoQuestProcess()
    {
        if (questList?.Count > 0)
            foreach (Quest q in questList.ToArray())
            {
                if (q.updateAction != null) q.updateAction();
            }
    }
    public static void DoQuestPrepare(SceneIndex location)
    {
        if (questList?.Count > 0)
            foreach (Quest q in questList.ToArray())
            {
                // Debug.Log(q.questName + " " + q.location.ToString());
                if (q.location == location && q.prepareAction != null) q.prepareAction();
            }
    }
    public static void DoQuest(Quest.Objective.Type type, int id, bool isQuestItem)
    {

        foreach (Quest quest in questList)
        {
            if (quest.objective.CheckIndexQuest(type, id, isQuestItem))
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
            if (q.objective.type == Quest.Objective.Type.talk &&
                q.objective.npc == idx &&
                q.location == (SceneIndex)StageHandler.instance.activeSceneIndex)
                return q.questId;
        }
        return -1;
    }
}
