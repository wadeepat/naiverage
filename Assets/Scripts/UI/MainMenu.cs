using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;
    [SerializeField] private SettingsMenu settingsMenu;
    [Header("Menu Buttons")]
    [SerializeField] private Button[] buttons;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        settingsMenu.LoadSettings();
        AudioManager.instance.Play("medievalTheme");
        if (!DataPersistenceManager.instance.HasSomeData())
        {
            buttons[1].interactable = false;
        }
    }
    public void NewGame()
    {
        AudioManager.instance.Play("click");
        saveSlotsMenu.ActivateMenu(false);
    }
    public void LoadGame()
    {
        AudioManager.instance.Play("click");
        saveSlotsMenu.ActivateMenu(true);
    }
    public void Settings()
    {
        AudioManager.instance.Play("click");
        settingsMenu.ActivateMenu();
    }
    private void DisableMenuButton()
    {
        foreach (Button btn in buttons)
        {
            btn.interactable = false;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
        if (!DataPersistenceManager.instance.HasSomeData())
        {
            buttons[1].interactable = false;
        }
    }
    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
