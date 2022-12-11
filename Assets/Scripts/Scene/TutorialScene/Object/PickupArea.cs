using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ActionHandler.instance.ActivateTutorialCard("Walking", false);
            ActionHandler.instance.ActivateTutorialCard("PickupItems", true);
            transform.Find("Light").gameObject.SetActive(false);
            Quest q = new Quest()
            {
                questId = 1,
                questName = "Collect Mushroom",
                questDescription = "",
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                compleltedAction = () =>
                {

                    ActionHandler.instance.ActivateTutorialCard("PickupItems", false);
                    ActionHandler.instance.ActivateTutorialCard("CraftPotion", true);
                    QuestLog.AddQuest(new Quest()
                    {
                        questId = 2,
                        questName = "Craft Potion",
                        questDescription = "",
                        MPReward = 0,
                        SBReward = "",
                        questCategory = 0,
                        objective = new Quest.Objective()
                        {
                            objectiveId = 1,
                            type = Quest.Objective.Type.interact,
                            amount = 1,
                        },
                        updateAction = () =>
                        {
                            if (CanvasManager.instance.GetCanvasObject("Panel").transform.Find("Character panel").gameObject.activeSelf)
                            {
                                QuestLog.CompleteQuest(QuestLog.GetQuestById(2));
                            }
                        },
                        compleltedAction = () =>
                        {
                            ActionHandler.instance.ActivateTutorialCard("CraftPotion", false);
                            // StageHandler.instance.EventTrigger("SataAppear");
                            ActionHandler.instance.TriggerQuestFromDialogue(3);
                            GameObject.Destroy(this);
                        },
                    });
                },
                objective = new Quest.Objective()
                {
                    objectiveId = 1,
                    type = Quest.Objective.Type.collect,
                    amount = 1,
                },
            };
            QuestLog.CompleteQuest(QuestLog.GetQuestById(0));
            QuestLog.AddQuest(q);
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     //TODO finished pickupItems by quest
    //     if (other.gameObject.tag == "Player" && InputManager.instance.GetInteractPressed())
    //     {
    //         ActionHandler.instance.ActivateTutorialCard("PickupItems", false);
    //         ActionHandler.instance.ActivateTutorialCard("UsePotion", true);
    //         DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("SataCall"));
    //         GameObject.Destroy(this);
    //     }
    // }
}
