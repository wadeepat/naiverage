using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Checkpoint : MonoBehaviour
{
    private GameObject interactObject;
    private TextMeshProUGUI text;
    private void Start()
    {
        interactObject = GameObject.Find("Canvas").transform.Find("InteractText").gameObject;
        text = interactObject.GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (this.enabled && collider.gameObject.tag == "Player")
        {
            text.text = "Press F to save";
            interactObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (this.enabled &&
            other.gameObject.tag == "Player" &&
            InputManager.instance.GetInteractPressed() &&
            !DialogueManager.dialogueIsPlaying)
        {
            AudioManager.instance.Play("talk");
            ActionHandler.instance.AskToSave();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        interactObject.SetActive(false);
    }
}
