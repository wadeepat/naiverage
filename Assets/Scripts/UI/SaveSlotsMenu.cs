using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour, IDataPersistence
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private GameObject saveSlotsObject;
    [Header("Menu Buttons")]
    [SerializeField] private Button backBtn;
    [Header("Confirmation Popup")]
    [SerializeField] private ConfirmationPopupMenu confirmationPopupMenu;
    [Header("Input Text")]
    [SerializeField] private InputTextUI inputText;

    private SaveSlot[] saveSlots;
    private GameObject EditBtns;
    private bool isLoadingGame = false;
    private string saveName = "Didn'tLoad";
    private void Awake()
    {
        saveSlots = saveSlotsObject.GetComponentsInChildren<SaveSlot>();
        EditBtns = transform.Find("List/EditBtns").gameObject;
    }
    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        AudioManager.instance.Play("click");

        DisableMenuButton();
        // Debug.Log("Selected ID: " + saveSlot.GetProfileId());
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        //case: loading game
        if (isLoadingGame)
        {
            // DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            //TODO load the current screen
            // SceneLoadingManager.instance.LoadScene(SceneIndex.Rachne);
            SceneLoadingManager.instance.LoadScene(saveSlot.GetPlayerLocation());
        }
        //case: new game but the save slot has data
        else if (saveSlot.hasData)
        {
            confirmationPopupMenu.ActivateMenu(
                displayText: "เริ่มเกมด้วย slot นี้จะเขียนทับข้อมูลเก่า ยืนยันที่จะทำใช่หรือไม่?",
                enableCancelBtn: true,
                confirmAction: () =>
                {
                    inputText.ActivateMenu(
                        title: "ตั้งชื่อ slot",
                        cancelText: "ยกเลิก",
                        confirmAction: (string value) =>
                        {
                            if (value != "")
                            {
                                DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileId());

                                DataPersistenceManager.instance.NewGame();
                                this.saveName = value;
                                DataPersistenceManager.instance.SaveGame(true);
                                SceneLoadingManager.instance.LoadScene(SceneIndex.Rachne);
                                // DataPersistenceManager.instance.LoadGame(true);
                                // DataPersistenceManager.instance.SaveGame(true);
                                // ActivateMenu(this.isLoadingGame);
                            }
                        },
                        cancelAction: () =>
                        {
                            inputText.DeactivateMenu();
                            ActivateMenu(this.isLoadingGame);
                        }
                    );
                },
                //action of cancel btn
                cancelAction: () =>
                {
                    this.ActivateMenu(isLoadingGame);
                }
            );
        }
        //case: newgame with empty slot
        else
        {
            inputText.ActivateMenu(
            title: "ตั้งชื่อ slot",
            cancelText: "ยกเลิก",
            confirmAction: (string value) =>
            {
                if (value != "")
                {
                    DataPersistenceManager.instance.NewGame();
                    this.saveName = value;
                    DataPersistenceManager.instance.SaveGame(true);
                    SceneLoadingManager.instance.LoadScene(SceneIndex.Rachne);
                    // DataPersistenceManager.instance.LoadGame(true);
                    // DataPersistenceManager.instance.SaveGame(true);
                    // ActivateMenu(this.isLoadingGame);
                }
            },
            cancelAction: () =>
            {
                inputText.DeactivateMenu();
                ActivateMenu(this.isLoadingGame);
            }
        );

            // DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileId());
            // DataPersistenceManager.instance.NewGame();

            // DataPersistenceManager.instance.SaveGame(false);
            // SceneLoadingManager.instance.LoadScene(SceneIndex.Rachne);
        }
    }
    public void onBackClicked()
    {
        AudioManager.instance.Play("click");
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }
    public void onEditClicked(SaveSlot saveSlot)
    {
        AudioManager.instance.Play("click");
        DisableMenuButton();
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
        inputText.ActivateMenu(
            title: "เปลี่ยนชื่อ slot",
            cancelText: "ยกเลิก",
            confirmAction: (string value) =>
            {
                if (value != "")
                {
                    this.saveName = value;
                    DataPersistenceManager.instance.SaveGame(true);
                    DataPersistenceManager.instance.LoadGame(true);
                    ActivateMenu(this.isLoadingGame);

                }
            },
            cancelAction: () =>
            {
                inputText.DeactivateMenu();
                ActivateMenu(this.isLoadingGame);
            }
        );
    }
    public void onClearClicked(SaveSlot saveSlot)
    {
        AudioManager.instance.Play("click");
        DisableMenuButton();

        confirmationPopupMenu.ActivateMenu(
            "ยืนยันที่จะลบข้อมูล slot นี้ใช่หรือไม่?",
            true,
            () =>
            {
                AudioManager.instance.Play("delete");
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

            EditBtns.SetActive(isLoadingGame);
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

    public void LoadData(GameData data)
    {
        this.saveName = data.saveName;
        // Debug.Log("Load Name as : " + data.saveName);

        // throw new System.NotImplementedException();
    }

    public void SaveData(GameData data)
    {
        data.saveName = this.saveName;
        // Debug.Log("Save name as : " + data.saveName);
    }
}
