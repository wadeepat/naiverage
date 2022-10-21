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
    [Header("Confirmation Popup")]
    [SerializeField] private ConfirmationPopupMenu confirmationPopupMenu;
    private SaveSlot[] saveSlots;
    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = saveSlotsObject.GetComponentsInChildren<SaveSlot>();
    }
    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        AudioManager.instance.Play("click");

        DisableMenuButton();

        //case: loading game
        if (isLoadingGame)
        {
            DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            //TODO load the current screen
            SceneLoadingManager.instance.LoadScene("Tutorial");
        }
        //case: new game but the save slot has data
        else if (saveSlot.hasData)
        {
            confirmationPopupMenu.ActivateMenu(
                "Starting a New Game with this slot will override the currently saved data. Are you sure?",
                //action of confirm btn
                () =>
                {
                    DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
                    DataPersistenceManager.instance.NewGame();

                    DataPersistenceManager.instance.SaveGame();
                    SceneLoadingManager.instance.LoadScene("Tutorial");
                },
                //action of cancel btn
                () =>
                {
                    this.ActivateMenu(isLoadingGame);
                }
            );
        }
        //case: newgame with empty slot
        else
        {
            DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            DataPersistenceManager.instance.NewGame();

            DataPersistenceManager.instance.SaveGame();
            SceneLoadingManager.instance.LoadScene("Tutorial");
        }
        //if newGame
        // if (!isLoadingGame)
        // {
        //     DataPersistenceManager.instance.NewGame();
        // }
        // SceneLoadingManager.instance.LoadScene("Tutorial");
    }
    public void onBackClicked()
    {
        AudioManager.instance.Play("click");
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }
    public void onClearClicked(SaveSlot saveSlot)
    {
        AudioManager.instance.Play("click");
        DisableMenuButton();

        confirmationPopupMenu.ActivateMenu(
            "Are you sure to delete this saved data?",
            () =>
            {
                DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileId());
                ActivateMenu(isLoadingGame);
            },
            () =>
            {
                ActivateMenu(isLoadingGame);
            }
        );
        DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileId());
        ActivateMenu(isLoadingGame);
    }
    public void ActivateMenu(bool isLoadingGame)
    {
        this.gameObject.SetActive(true);
        this.isLoadingGame = isLoadingGame;

        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();

        backBtn.interactable = true;

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
