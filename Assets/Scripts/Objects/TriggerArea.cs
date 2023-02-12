using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private enum TriggerType { dialogue, eventName };
    [SerializeField] private TriggerType type;
    [SerializeField] private TextAsset dialogue;
    [SerializeField] private string eventName;
    private void OnTriggerEnter(Collider collider)
    {
        if (this.enabled && collider.gameObject.tag == "Player")
        {
            if (type == TriggerType.dialogue)
                DialogueManager.instance.EnterDialogueMode(dialogue);
            else StageHandler.instance.EventTrigger(eventName);
            GameObject.Destroy(this);
        }
    }
}
