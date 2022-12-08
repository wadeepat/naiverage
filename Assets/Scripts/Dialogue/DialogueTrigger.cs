using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private GameObject interactObject;
    private bool playerInRange;
    private TextMeshProUGUI text;

    private void Start()
    {
        interactObject = CanvasManager.instance.GetCanvasObject("InteractText");
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
