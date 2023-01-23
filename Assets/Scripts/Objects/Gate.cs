using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gate : MonoBehaviour
{
    [SerializeField] private SceneIndex toScene;
    private GameObject interactObject;
    private TextMeshProUGUI text;
    private void Start()
    {
        interactObject = CanvasManager.instance.GetCanvasObject("InteractText");
        text = interactObject.GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (this.enabled && collider.gameObject.tag == "Player")
        {
            text.text = "Press F to enter " + toScene.ToString();
            interactObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (this.enabled && other.gameObject.tag == "Player" && InputManager.instance.GetInteractPressed())
        {
            interactObject.SetActive(false);
            AudioManager.instance.Play("click");
            gameObject.GetComponent<BoxCollider>().enabled = false;
            SceneLoadingManager.instance.LoadScene(toScene);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (this.enabled && collider.gameObject.tag == "Player")
        {
            interactObject.SetActive(false);
        }
    }
}
