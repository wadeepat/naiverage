using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class GameMenu : MonoBehaviour
{
    [SerializeField] private ConfirmationPopupMenu confirmationPopupMenu;
    private GameObject _player;
    private ThirdPersonController _thirdPersonController;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _thirdPersonController = _player.GetComponent<ThirdPersonController>();
    }
    public void ClickedResume()
    {
        this.DeactivateMenu();
    }
    public void ClickedOpitons()
    {
        // TODO implement options about sound and graphics
    }
    public void ClickedMainMenu()
    {
        confirmationPopupMenu.ActivateMenu(
            "Are you sure to go to MainMenu ?\n the data after checkpoint will is not be saved.(for now is saved)",
            () =>
            {
                DataPersistenceManager.instance.SaveGame();
                AudioManager.instance.StopAllTrack();
                SceneLoadingManager.instance.LoadScene("MainMenu");
            },
            () =>
            {
                this.ActivateMenu();
            }
        );
    }
    public void ActivateMenu()
    {
        if (DialogueManager.dialogueIsPlaying)
        {
            if (this.gameObject.activeSelf)
            {
                this.DeactivateMenu();
            }
        }
        else
        {
            this.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            DialogueManager.dialogueIsPlaying = true;
            _thirdPersonController.SetLockCameraPosition(true);
        }
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        DialogueManager.dialogueIsPlaying = false;
        _thirdPersonController.SetLockCameraPosition(false);
    }
}
