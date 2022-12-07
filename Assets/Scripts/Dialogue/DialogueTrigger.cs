using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject interactObject;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;
    private TextMeshProUGUI text;
    // private void Start()
    // {
    //     playerInRange = false;
    //     // visualCue.SetActive(false);
    // }
    // private void Update()
    // {
    //     if (playerInRange)
    //     {
    //         text.text = "Press F to talk";
    //         visualCue.SetActive(true);
    //         if (InputManager.instance.GetInteractPressed() && !DialogueManager.dialogueIsPlaying)
    //         {
    //             print("to dialogue");
    //             DialogueManager.instance.EnterDialogueMode(inkJSON);
    //             // Debug.Log(inkJSON.text);
    //         }
    //     }
    //     else
    //     {
    //         visualCue.SetActive(false);
    //     }
    // }
    // private void OnTriggerEnter(Collider collider)
    // {
    //     if (collider.gameObject.tag == "Player")
    //     {
    //         playerInRange = true;
    //     }
    // }
    // private void OnTriggerExit(Collider collider)
    // {
    //     if (collider.gameObject.tag == "Player")
    //     {
    //         playerInRange = false;
    //     }
    // }
    private void Start()
    {
        text = interactObject.GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            text.text = "Press F to talk ";
            interactObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && InputManager.instance.GetInteractPressed() && !DialogueManager.dialogueIsPlaying)
        {
            //TODO talk sound
            // AudioManager.instance.Play("click");
            DialogueManager.instance.EnterDialogueMode(inkJSON);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            interactObject.SetActive(false);
        }
    }
}
