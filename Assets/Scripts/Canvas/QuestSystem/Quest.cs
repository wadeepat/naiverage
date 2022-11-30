using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Quest 
{
    public Objective objective;
    public string questName;
    public string questDescription;
    public int MPReward;
    public string SBReward;
    public short questCategory;
    
    [System.Serializable]   
    public class Objective
    {
        public enum Type {kill, talk, collect};
        public Type type;
        public int amount;
        // public int objectiveId{ get; private set;}
        [System.NonSerialized]
        public int objectiveId;
        public int currentAmount;

        public bool CheckObjectiveCompleted(Type type, int id){
            if(this.type == type && id == objectiveId) currentAmount++;
            return currentAmount >= amount;
        }

        public bool ForceAddObjective(int amount){
            currentAmount += amount;
            return currentAmount >= amount;
        }

        public bool CheckIndexQuest(Type type, int id){
            if(this.type == type && id == objectiveId) return true;
            else return false;
        }
        public bool CheckCompletedQuest(Quest quest){
            return quest.objective.currentAmount == quest.objective.amount;
        }


        public override string ToString () {
            switch(type){
                case Type.kill:
                    return "Kill "+ /* MonsterList.MonsterNameFromID(objectiveId) + " " +*/ currentAmount + " / " + amount;
                case Type.talk:
                    return "Talk to " /* + NpcList.NpcName(objectiveId) + ""+*/;
                case Type.collect:
                    return "Collect " + /*itemList.ItemName(objectiveId) + " " + */ Database.itemList[objectiveId].name + " " + currentAmount + " / " + amount;
            }
            return "";
        }

    }
    
    
}
