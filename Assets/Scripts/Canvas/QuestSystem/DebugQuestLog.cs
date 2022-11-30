using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugQuestLog : MonoBehaviour
{

    

    void Start()
    {
        Quest q = new Quest();
        q.questName = "Quest test 1";
        q.questDescription = "Test quest only collect";
        q.MPReward = Random.Range(100,1000);
        q.SBReward = "SBName";
        q.questCategory = 0;
        q.objective = new Quest.Objective();
        q.objective.objectiveId = 1;
        q.objective.type = Quest.Objective.Type.collect;
        // q.objective.type = (Quest.Objective.Type)Random.Range(0,2);
        q.objective.amount = Random.Range(1,5);

        Quest q2 = new Quest();
        q2.questName = "Quest test 2";
        q2.questDescription = "Test quest (kill)";
        q2.MPReward = Random.Range(100,1000);
        q2.SBReward = "SBName";
        q2.questCategory = 0;
        q2.objective = new Quest.Objective();
        q2.objective.objectiveId = 1;
        q2.objective.type = Quest.Objective.Type.kill;
        // q.objective.type = (Quest.Objective.Type)Random.Range(0,2);
        q2.objective.amount = Random.Range(1,5);

        QuestLog.AddQuest(q);
        QuestLog.AddQuest(q2);
        QuestLog.AddQuest(getNext(3));
    }

    private Quest getNext(int i) {
        Quest q = new Quest();
        q.questName = "Quest test " + i;
        q.questDescription = "Test quest only collect";
        q.MPReward = Random.Range(100,1000);
        q.SBReward = "SBName";
        q.questCategory = 0;
        q.objective = new Quest.Objective();
        q.objective.objectiveId = 2;
        q.objective.type = Quest.Objective.Type.collect;
        // q.objective.type = (Quest.Objective.Type)Random.Range(0,2);
        q.objective.amount = Random.Range(1,5);
        return q;
    }

    private IEnumerator AddQuest(int iter) {
        for (int i = 0; i < iter; i++) {
            QuestLog.AddQuest(getNext(i));
            yield return new WaitForSeconds(3f);
        }
    }

    
}
