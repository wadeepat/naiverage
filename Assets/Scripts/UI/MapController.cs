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
    }
    public void MapIsClicked(string sceneName)
    {
        AudioManager.instance.Play("click");
        SceneIndex scene = (SceneIndex)System.Enum.Parse(typeof(SceneIndex), sceneName);
        if ((int)scene != activeSceneIndex)
        {
            // if (PlayerManager.instance.mapEnable[scene])
            // {
            Debug.Log("loading" + sceneName);
            DeactivateMenu();
            SceneLoadingManager.instance.LoadScene(scene);
            // }
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
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;
            // DialogueManager.dialogueIsPlaying = true;
            DialogueManager.dialogueIsPlaying = true;
            DialogueManager.instance.LockCamera();
            DialogueManager.instance.EnablePlayerControll();

            activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            this.gameObject.SetActive(true);

            //TODO: set only map that able to warp
            SetEnableMapInteract();
            // SetAllButtonsInteract(true);
        }
    }
    public void DeactivateMenu()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
        // DialogueManager.dialogueIsPlaying = false;
        DialogueManager.dialogueIsPlaying = false;
        DialogueManager.instance.UnlockCamera();
        DialogueManager.instance.DisablePlayerControll();
        this.gameObject.SetActive(false);
        SetAllButtonsInteract(false);
    }
    private void SetEnableMapInteract()
    {
        int i = 1;
        foreach (Button btn in buttons)
        {
            if (PlayerManager.instance.mapEnable[(SceneIndex)i])
            {
                btn.interactable = true;
                btn.transform.Find("Lock").gameObject.SetActive(false);

            }
            else
            {
                btn.interactable = false;
                btn.transform.Find("Lock").gameObject.SetActive(true);
            }
            btn.transform.Find("Pin").gameObject.SetActive(activeSceneIndex == i);
            i++;
        }
    }
    private void SetAllButtonsInteract(bool isInteract)
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
}
