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
    public static ActionHandler instance;

    private GameObject CanvasObject;
    private ChapterCard chapterCardScript;
    private GameObject TutorialGuidingObject;
    private GameObject[] tutorialGuidingCards;
    private InputTextUI UI_Input_Window;
    private ConfirmationPopupMenu confirmationPopup;

    private List<int> questIdxList = new List<int>();
    private void Awake()
    {
        instance = this;
        if (SceneManager.GetActiveScene().buildIndex != (int)SceneIndex.BlackScene)
        {
            CanvasObject = GameObject.Find("Canvas");
            TutorialGuidingObject = CanvasObject.transform.Find("TutorialGuiding").gameObject;
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
        DeactivateAllCard();
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
    private void DeactivateAllCard()
    {
        // foreach (GameObject card in TutorialGuidingObject.transform)
        // {
        //     card.SetActive(false);
        // }
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
                DataPersistenceManager.instance.SaveGame(true);
                SceneLoadingManager.instance.LoadScene(SceneIndex.BlackScene);
                break;
            case "Ending2":
                playerPath = 2;
                DataPersistenceManager.instance.SaveGame(true);
                SceneLoadingManager.instance.LoadScene(SceneIndex.BlackScene);
                break;
            case "Ending3":
                playerPath = 3;
                DataPersistenceManager.instance.SaveGame(true);
                SceneLoadingManager.instance.LoadScene(SceneIndex.BlackScene);
                break;
            case "TrueEnding":
                playerPath = 4;
                SceneLoadingManager.instance.LoadScene(SceneIndex.BlackScene);
                break;
            default:
                Debug.LogWarning("There is no action: " + action);
                break;
        }
    }
    public bool IsInputWindowActivated()
    {
        if (UI_Input_Window != null)
            return UI_Input_Window.IsActivated();
        else return false;
    }

    public void AskToSave()
    {
        if (DialogueManager.dialogueIsPlaying) Debug.LogWarning("From ComfirmPopup there is other using dialogueIsPlaying");
        SetForActivateUI();
        confirmationPopup.ActivateMenu(
            displayText: $"ยืนยันที่จะบันทึกเกมใน slot ที่ชื่อ <color={Database.COLORS["char"]}>{playerName}</color> อยู่ใช่หรือไม่?",
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
    private void GetPlayerName()
    {
        if (DialogueManager.dialogueIsPlaying) Debug.LogWarning("From InputField there is other using dialogueIsPlaying");
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
        if (StageHandler.instance.activeSceneIndex != (int)SceneIndex.BlackScene)
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
        DialogueManager.dialogueIsPlaying = true;
        // DialogueManager.instance.LockCamera();
        PlayerManager.instance?.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(true);
        DialogueManager.instance.EnablePlayerControll();
    }
    private void ResetForDeactivateUI()
    {
        DialogueManager.dialogueIsPlaying = false;
        // DialogueManager.instance.UnlockCamera();
        PlayerManager.instance?.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(false);
        DialogueManager.instance.DisablePlayerControll();
    }
}
