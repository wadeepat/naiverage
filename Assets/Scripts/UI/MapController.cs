using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;
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
    private void Update()
    {
        if (InputManager.instance.GetBackPressed()) this.DeactivateMenu();
    }
    public void MapIsClicked(string sceneName)
    {
        AudioManager.instance.Play("click");
        SceneIndex scene = (SceneIndex)System.Enum.Parse(typeof(SceneIndex), sceneName);
        if ((int)scene != activeSceneIndex)
        {
            DeactivateMenu();
            SceneLoadingManager.instance.LoadScene(scene);
        }
    }
    public void ActivateMenu()
    {
        if (GameObject.Find("Canvas")?.transform.Find("LoadingScreen")?.gameObject.activeSelf == true) return;
        if (DialogueManager.dialogueIsPlaying ||
            ActionHandler.instance.IsSomeWindowsActivated())
        {
            if (this.gameObject.activeSelf)
            {
                DeactivateMenu();
            }
        }
        else
        {
            DialogueManager.dialogueIsPlaying = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlayerManager.instance.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(true);
            activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            this.gameObject.SetActive(true);

            SetEnableMapInteract();
        }
    }
    public void DeactivateMenu()
    {
        DialogueManager.dialogueIsPlaying = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerManager.instance.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(false);
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
