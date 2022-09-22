using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextAsset inkJSON;
    void Start()
    {
        // GetComponent<DialogueTrigger>().EnterDialogueMode();
        Debug.Log("Start from Tutorial Script");
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        // Debug.Log("Start Dialogue");
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
    public void testClick()
    {
        Debug.Log("Click");
    }
}
