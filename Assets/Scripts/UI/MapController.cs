using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MapController : MonoBehaviour
{
    private int activeSceneIndex;
    private Transform ButtonsObject;
    private Button[] buttons;
    private void Awake()
    {
        ButtonsObject = this.gameObject.transform.Find("Buttons");
        buttons = ButtonsObject.GetComponentsInChildren<Button>();

        // if (!ButtonsObject) Debug.Log("NULLLLL");
        // foreach (Transform btn in ButtonsObject)
        // {
        //     Button addBtn = btn.GetComponent<Button>();
        //     Debug.Log(addBtn.name);
        //     buttons.Add(addBtn);
        // }
    }
    public void MapIsClicked(string sceneName)
    {
        Debug.Log("Clicked " + sceneName);
        SetButtonsInteract(false);
        int index = (int)(SceneIndex)System.Enum.Parse(typeof(SceneIndex), sceneName);
        if (index != activeSceneIndex)
        {
            if (index > 2) return;
            PlayerManager.instance.ChangePlayerLocation(sceneName);
            SceneLoadingManager.instance.LoadScene(sceneName);
        }
        // PlayerManager.instance.playerLocation
    }
    private void SetButtonsInteract(bool isInteract)
    {
        foreach (Button btn in buttons)
        {
            btn.interactable = isInteract;
            if (isInteract)
            {
                int index = (int)(SceneIndex)System.Enum.Parse(typeof(SceneIndex), btn.name);
                btn.transform.Find("Pin").gameObject.SetActive(activeSceneIndex == index);
            }
        }
    }
    public void ActivateMenu()
    {
        if (DialogueManager.dialogueIsPlaying)
        {
            if (this.gameObject.activeSelf)
            {
                DeactivateMenu();
            }
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            DialogueManager.dialogueIsPlaying = true;

            activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            this.gameObject.SetActive(true);

            //TODO: set only map that able to warp
            SetButtonsInteract(true);
        }
    }
    public void DeactivateMenu()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        DialogueManager.dialogueIsPlaying = false;
        this.gameObject.SetActive(false);
        SetButtonsInteract(false);
    }
}
