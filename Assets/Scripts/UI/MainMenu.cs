using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;
    [Header("Menu Buttons")]
    [SerializeField] private Button[] buttons;
    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        Cursor.visible = true;
        AudioManager.instance.Play("medievalTheme");
        if (!DataPersistenceManager.instance.HasGameData())
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
    }
    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
