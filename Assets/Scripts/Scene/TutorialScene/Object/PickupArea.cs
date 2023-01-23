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

            QuestLog.CompleteQuest(QuestLog.GetActiveQuestById(0));
            GameObject.Destroy(this);
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
