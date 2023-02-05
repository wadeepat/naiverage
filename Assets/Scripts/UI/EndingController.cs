using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    void Start()
    {
        if (ActionHandler.instance.playerPath == 0)
        {
            DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(4, "Ending3"));
        }
    }

}
