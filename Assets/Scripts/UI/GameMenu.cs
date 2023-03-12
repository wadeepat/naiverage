using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class GameMenu : MonoBehaviour
{
    [SerializeField] private ConfirmationPopupMenu confirmationPopupMenu;
    [SerializeField] private SettingsMenu settingsMenu;
    // private GameObject _player;
    // private ThirdPersonController _thirdPersonController;
    // private void Awake()
    // {
    //     _player = GameObject.FindGameObjectWithTag("Player");
    //     _thirdPersonController = _player.GetComponent<ThirdPersonController>();
    // }
    private void Start()
    {
        settingsMenu.DeactivateMenu();
    }
    private void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void ClickedResume()
    {
        this.DeactivateMenu();
    }
    public void ClickedOpitons()
    {
        settingsMenu.ActivateMenu();
    }
    public void ClickedMainMenu()
    {
        confirmationPopupMenu.ActivateMenu(
            "ต้องการที่จะกลับไปที่เมนูหลักใช่หรือไม่?\nข้อมูลหลังจากจุด checkpoint",
            true,
            () =>
            {
                //TODO change to save when checkpoint
                // DataPersistenceManager.instance.SaveGame(true);
                AudioManager.instance.StopAllTrack();
                SceneLoadingManager.instance.LoadScene(SceneIndex.MainMenu);
                this.ActivateMenu();
            },
            () =>
            {
                this.ActivateMenu();
            }
        );
        // confirmationPopupMenu.ActivateMenu(
        //     "ต้องการที่จะกลับไปที่เมนูหลักใช่หรือไม่?\nข้อมูลหลังจากจุด checkpoint จะไม่ถูกบันทึก(ตอนนี้เซฟ)",
        //     true,
        //     () =>
        //     {
        //         //TODO change to save when checkpoint
        //         DataPersistenceManager.instance.SaveGame(true);
        //         AudioManager.instance.StopAllTrack();
        //         SceneLoadingManager.instance.LoadScene(SceneIndex.MainMenu);
        //         this.ActivateMenu();
        //     },
        //     () =>
        //     {
        //         this.ActivateMenu();
        //     }
        // );
    }
    public void ActivateMenu()
    {
        if (GameObject.Find("Canvas")?.transform.Find("LoadingScreen")?.gameObject.activeSelf == true) return;
        if (DialogueManager.dialogueIsPlaying ||
        ActionHandler.instance.IsSomeWindowsActivated())
        {
            if (this.gameObject.activeSelf)
            {
                if (settingsMenu.IsActivated()) settingsMenu.DeactivateMenu();
                else this.DeactivateMenu();
            }
        }
        else
        {
            InputManager.instance.GetBackPressed();
            this.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            DialogueManager.dialogueIsPlaying = true;
            PlayerManager.instance.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(true);
            // _thirdPersonController.SetLockCameraPosition(true);
        }
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        DialogueManager.dialogueIsPlaying = false;
        PlayerManager.instance.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(false);
        // _thirdPersonController.SetLockCameraPosition(false);
    }
}
