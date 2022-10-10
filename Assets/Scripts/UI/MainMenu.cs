using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;
    [Header("Menu Buttons")]
    [SerializeField] private Button[] buttons;
    private void Start()
    {
        Cursor.visible = true;
        AudioManager.instance.Play("medievalTheme");
        if (!DataPersistenceManager.instance.HasGameData())
        {
            buttons[1].interactable = false;
        }
    }
    public void NewGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.instance.Play("click");
        DisableMenuButton();
        Debug.Log("Click NewGame");

        DataPersistenceManager.instance.NewGame();
        // LoadScene("Tutorial");
        SceneLoadingManager.instance.LoadScene("Tutorial");
        AudioManager.instance.Stop("medievalTheme");
    }
    public void LoadGame()
    {
        AudioManager.instance.Play("click");
        saveSlotsMenu.ActivateMenu();
        DisableMenuButton();
        // SceneLoadingManager.instance.LoadScene("Tutorial");
        // AudioManager.instance.Stop("medievalTheme");

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
