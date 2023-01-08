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
            // SceneLoadingManager.instance.LoadScene(SceneIndex.Rachne);
            SceneLoadingManager.instance.LoadScene(saveSlot.GetPlayerLocation());
        }
        //case: new game but the save slot has data
        else if (saveSlot.hasData)
        {
            confirmationPopupMenu.ActivateMenu(
                "เริ่มเกมด้วย slot นี้จะเขียนทับข้อมูลเก่า ยืนยันที่จะทำใช่หรือไม่?",
                //action of confirm btn
                () =>
                {
                    DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
                    DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileId());
                    DataPersistenceManager.instance.NewGame();

                    DataPersistenceManager.instance.SaveGame(true);
                    SceneLoadingManager.instance.LoadScene(SceneIndex.Rachne);
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
            // DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileId());
            DataPersistenceManager.instance.NewGame();

            DataPersistenceManager.instance.SaveGame(false);
            SceneLoadingManager.instance.LoadScene(SceneIndex.Rachne);
        }
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
            "ยืนยันที่จะลบข้อมูล slot นี้ใช่หรือไม่?",
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
        // DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileId());
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
