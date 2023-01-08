using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class Quest
{
    public int questId;
    public Objective objective;
    public string questName;
    public string questDescription;
    public int MPReward;
    public string SBReward;
    public short questCategory;
    public UnityAction addAction;
    public UnityAction updateAction;
    public UnityAction compleltedAction;

    [System.Serializable]
    public class Objective
    {
        public enum Type { kill, talk, collect, interact };
        public Type type;
        public NPCIndex npc;
        public int amount;
        // public int objectiveId{ get; private set;}
        [System.NonSerialized]
        public int objectiveId;
        public int currentAmount;
        // private bool interact = false;
        public bool CheckObjectiveCompleted(Type type, int id)
        {
            // if (type == Type.interact) return interact;
            if (this.type == type && id == objectiveId)
            {
                currentAmount++;
                return currentAmount >= amount;
            }
            return false;
        }

        public bool ForceAddObjective(int amount)
        {
            currentAmount += amount;
            return currentAmount >= amount;
        }

        public bool CheckIndexQuest(Type type, int id)
        {
            if (this.type == type && id == objectiveId) return true;
            else return false;
        }
        public bool CheckCompletedQuest(Quest quest)
        {
            // if (quest.objective.type == Type.interact) return interact;
            return quest.objective.currentAmount == quest.objective.amount;
        }
        // public void SetObjectiveInteract(bool finished)
        // {
        //     this.interact = finished;
        // }

        public override string ToString()
        {
            switch (type)
            {
                case Type.kill:
                    return "Kill " + /* MonsterList.MonsterNameFromID(objectiveId) + " " +*/ currentAmount + " / " + amount;
                case Type.talk:
                    return "Talk to " /* + NpcList.NpcName(objectiveId) + ""+*/;
                case Type.collect:
                    return "Collect " + /*itemList.ItemName(objectiveId) + " " + */ Database.itemList[objectiveId].name + " " + currentAmount + " / " + amount;
                case Type.interact:
                    return "Interact to press or walk to";
            }
            return "";
        }

    }


}
