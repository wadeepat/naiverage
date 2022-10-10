using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private GameObject saveSlotsObject;
    [Header("Menu Buttons")]
    [SerializeField] private Button backBtn;
    private SaveSlot[] saveSlots;
    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = saveSlotsObject.GetComponentsInChildren<SaveSlot>();
    }
    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        AudioManager.instance.Play("click");
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        //if newGame
        if (!isLoadingGame)
        {
            DataPersistenceManager.instance.NewGame();
        }
        SceneLoadingManager.instance.LoadScene("Tutorial");
    }
    public void onBackClicked()
    {
        AudioManager.instance.Play("click");
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }
    public void ActivateMenu(bool isLoadingGame)
    {
        this.gameObject.SetActive(true);
        this.isLoadingGame = isLoadingGame;
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();
        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);

            if (isLoadingGame && profileData == null)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
            }
        }
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void DisableMenuButton()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        backBtn.interactable = false;
    }
}
