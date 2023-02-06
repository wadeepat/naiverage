using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndingController : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
        TextAsset file = null;
        switch (ActionHandler.instance.playerPath)
        {
            case 0:
                // Test only
                file = DialogueManager.instance.GetDialogueFile(4, "Ending3");
                break;
            case 1:
                file = DialogueManager.instance.GetDialogueFile(4, "Ending1");
                break;
            case 2:
                file = DialogueManager.instance.GetDialogueFile(4, "Ending2");
                break;
            case 3:
                file = DialogueManager.instance.GetDialogueFile(4, "Ending3");
                break;
            case 4:
                file = DialogueManager.instance.GetDialogueFile(4, "TrueEnding");
                break;
        }
        DialogueManager.instance.EnterDialogueMode(file);
    }

}
