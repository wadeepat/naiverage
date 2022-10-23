using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;
    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }
    private void Update()
    {
        if (playerInRange)
        {
            print("sata");
            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                print("to dialogue");
                DialogueManager.instance.EnterDialogueMode(inkJSON);
                // Debug.Log(inkJSON.text);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public void EnterDialogueMode()
    {
        DialogueManager.instance.EnterDialogueMode(inkJSON);
    }
}
