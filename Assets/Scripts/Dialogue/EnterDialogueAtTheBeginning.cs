using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialogueAtTheBeginning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextAsset inkJSON;
    // private float time = 1.5f;
    void Start()
    {
        Debug.Log(DialogueManager.instance.GetVariableState("readOP"));
        if (DialogueManager.instance.GetVariableState("readOP").ToString().Equals("false"))
        {
            Debug.Log("Enter dialoguellllll");
            DialogueManager.instance.EnterDialogueMode(inkJSON);
        }
        AudioManager.instance.Play("forestBackground");
    }
}
