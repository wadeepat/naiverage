using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using StarterAssets;
public class ActionHandler : MonoBehaviour, IDataPersistence
{
    [Header("INK Files")]
    [SerializeField] private TextAsset SataKnowPlayerNameJSON;
    public string playerName { get; private set; }
    public int playerPath { get; private set; }
    public ChapterCard chapterCardScript { get; private set; }

    private GameObject CanvasObject;
    private GameObject TutorialGuidingObject;
    private GameObject[] tutorialGuidingCards;
    public static GameObject PotionPanel { get; private set; }
    private InputTextUI UI_Input_Window;
    private ConfirmationPopupMenu confirmationPopup;

    private List<int> questIdxList = new List<int>();
    public static ActionHandler instance;
    private void Awake()
    {
        instance = this;
        if (SceneManager.GetActiveScene().buildIndex != (int)SceneIndex.BlackScene)
        {
            CanvasObject = GameObject.Find("Canvas");
            TutorialGuidingObject = CanvasObject.transform.Find("TutorialGuiding").gameObject;
            chapterCardScript = CanvasObject.transform.Find("ChapterCard").GetComponent<ChapterCard>();
            PotionPanel = CanvasObject.transform.Find("Panel/Character panel/All funtion/Potion").gameObject;
            UI_Input_Window = CanvasObject.transform.Find("UI_Input_Window").GetComponent<InputTextUI>();
            confirmationPopup = CanvasObject.transform.Find("ConfirmationPopupMenu").GetComponent<ConfirmationPopupMenu>();
        }
    }
    private void OnEnable()
    {
        UsePotions.onUsePotion += CheckIsUsePotionQuest;
    }
    private void OnDisable()
    {
        UsePotions.onUsePotion -= CheckIsUsePotionQuest;
        DeactivateAllElement();
    }
    public void CheckIsUsePotionQuest()
    {
        Quest q = QuestLog.GetActiveQuestById(3);
        if (q != null) QuestLog.CompleteQuest(q);
    }
    public void ActivateTutorialCard(string cardName, bool active)
    {
        TutorialGuidingObject.transform.Find(cardName).gameObject.SetActive(active);
    }
    private void DeactivateAllElement()
    {
        foreach (Transform card in TutorialGuidingObject.transform)
        {
            card.gameObject.SetActive(false);
        }
        confirmationPopup.gameObject.SetActive(false);

    }
    public void ReceiveActionThenContinueStory(string action, UnityAction ContinueStory)
    {
        switch (action)
        {
            case "GetPlayerName":
                GetPlayerName();
                break;
            case "Ending1":
                playerPath = 1;
                PlayerManager.instance.playerLocation = SceneIndex.BlackScene;
                DataPersistenceManager.instance.SaveGame(true);
                SceneLoadingManager.instance.LoadScene(SceneIndex.BlackScene);
                break;
            case "Ending2":
                playerPath = 2;
                PlayerManager.instance.playerLocation = SceneIndex.BlackScene;
                DataPersistenceManager.instance.SaveGame(true);
                SceneLoadingManager.instance.LoadScene(SceneIndex.BlackScene);
                break;
            case "Ending3":
                playerPath = 3;
                PlayerManager.instance.playerLocation = SceneIndex.BlackScene;
                DataPersistenceManager.instance.SaveGame(true);
                SceneLoadingManager.instance.LoadScene(SceneIndex.BlackScene);
                break;
            case "TrueEnding":
                playerPath = 4;
                PlayerManager.instance.playerLocation = SceneIndex.BlackScene;
                DataPersistenceManager.instance.SaveGame(true);
                SceneLoadingManager.instance.LoadScene(SceneIndex.BlackScene);
                break;
            default:
                Debug.LogWarning("There is no action: " + action);
                break;
        }
    }
    public bool IsSomeWindowsActivated()
    {
        if (UI_Input_Window?.IsActivated() == true)
            return true;
        else if (chapterCardScript?.IsActivated() == true)
            return true;
        else if (confirmationPopup?.IsActivated() == true)
            return true;
        else return false;
    }

    public void AskToSave()
    {
        // if (DialogueManager.dialogueIsPlaying) Debug.LogWarning("From ComfirmPopup there is other using dialogueIsPlaying");
        SetForActivateUI();
        confirmationPopup.ActivateMenu(
            displayText: $"ยืนยันที่จะบันทึกเกมใน slot ที่ชื่อ <color={Database.COLORS["char"]}>{playerName}</color> อยู่ใช่หรือไม่?",
            enableCancelBtn: true,
            confirmAction: () =>
            {
                AudioManager.instance.Play("save");
                DataPersistenceManager.instance.SaveGame(true);
                DataPersistenceManager.instance.LoadGame(true);
                ResetForDeactivateUI();
            },
            cancelAction: () => { ResetForDeactivateUI(); }
        );
    }
    public void AskToLoad()
    {
        AudioManager.instance.StopAllTrack();
        AudioManager.instance.Play("sadness");
        SetForActivateUI();
        confirmationPopup.ActivateMenu(
            displayText: $"เจ้าได้ต่อสู้จนถึงแก่ความตาย\nจึงต้องกลับไปเริ่มใหม่ยังจุดที่ save ล่าสุด",
            enableCancelBtn: false,
            confirmAction: () =>
            {
                AudioManager.instance.Play("save");
                DataPersistenceManager.instance.LoadGame(true);
                ResetForDeactivateUI();
                SceneLoadingManager.instance.LoadScene(PlayerManager.instance.playerLocation);
            },
            cancelAction: () => { ResetForDeactivateUI(); }
        );
    }
    private void GetPlayerName()
    {
        // if (DialogueManager.dialogueIsPlaying) Debug.LogWarning("From InputField there is other using dialogueIsPlaying");
        SetForActivateUI();
        UI_Input_Window.ActivateMenu(
            "เจ้าชื่ออะไร",
            (string inputValue) =>
            {
                if (inputValue != "")
                {
                    ResetForDeactivateUI();
                    playerName = inputValue;
                    Ink.Runtime.Value value = Ink.Runtime.Value.Create(playerName);
                    DialogueManager.instance.dialogueVariables.SetVariableState("name", value);
                    DialogueManager.instance.EnterDialogueMode(SataKnowPlayerNameJSON);
                }
            },
            () =>
            {

            }
        );
    }
    public bool IsQuestIdxInSave(int idx)
    {
        foreach (int i in questIdxList)
            if (i == idx) return true;
        return false;
    }
    public void LoadData(GameData data)
    {
        // Debug.Log("Load from Action Handler");
        playerName = data.name;
        playerPath = data.playerPath;
        if (SceneManager.GetActiveScene().buildIndex != (int)SceneIndex.BlackScene)
        {
            questIdxList = data.questIdxList;
            QuestLog.LoadQuest(data.questIdxList, data.completedQuestIdxList);
        }
    }

    public void SaveData(GameData data)
    {
        // Debug.Log("Save from Action Handler");
        data.name = playerName;
        data.playerPath = playerPath;

        if (StageHandler.instance.activeSceneIndex != (int)SceneIndex.BlackScene)
        {
            var allQuestList = QuestLog.GetAllQuestList();


            data.questIdxList = allQuestList.q;
            data.completedQuestIdxList = allQuestList.c;
        }
    }
    private void SetForActivateUI()
    {
        // DialogueManager.dialogueIsPlaying = true;
        // DialogueManager.instance.LockCamera();
        PlayerManager.instance?.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(true);
        DialogueManager.instance.EnablePlayerControll();
    }
    private void ResetForDeactivateUI()
    {
        // DialogueManager.dialogueIsPlaying = false;
        // DialogueManager.instance.UnlockCamera();
        PlayerManager.instance?.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(false);
        DialogueManager.instance.DisablePlayerControll();
    }
}
