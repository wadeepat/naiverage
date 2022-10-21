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
        if (!DialogueManager.instance.GetVariableState("readOP"))
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON);
        }
        AudioManager.instance.Play("forestBackground");
    }
}
