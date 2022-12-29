using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ink.Runtime;
public class ActionHandler : MonoBehaviour, IDataPersistence
{
    enum TutorialCard
    {
        Walking,
        PickUpItems,
        NormalAttack,
    }
    [Header("Conponents")]
    [Header("INK Files")]
    [SerializeField] private TextAsset SataKnowPlayerNameJSON;
    public string playerName { get; private set; }
    private GameObject TutorialGuidingObject;
    private GameObject[] tutorialGuidingCards;
    public static ActionHandler instance;
    private InputTextUI UI_Input_Window;
    private GameObject CanvasObject;
    private void Awake()
    {
        instance = this;
        // TutorialGuidingObject = CanvasManager.instance.GetCanvasObject("TutorialGuiding");
        // UI_Input_Window = CanvasManager.instance.GetCanvasObject("UI_Input_Window").GetComponent<InputTextUI>();
        CanvasObject = GameObject.Find("Canvas");
        TutorialGuidingObject = CanvasObject.transform.Find("TutorialGuiding").gameObject;
        UI_Input_Window = CanvasObject.transform.Find("UI_Input_Window").GetComponent<InputTextUI>();
    }
    private void OnEnable()
    {
        UsePotions.onUsePotion += CheckIsUsePotionQuest;
    }
    private void OnDisable()
    {
        UsePotions.onUsePotion -= CheckIsUsePotionQuest;
    }
    public void CheckIsUsePotionQuest()
    {
        Quest q = QuestLog.GetQuestById(3);
        if (q != null) QuestLog.CompleteQuest(q);
    }
    public void ActivateTutorialCard(string cardName, bool active)
    {
        TutorialGuidingObject.transform.Find(cardName).gameObject.SetActive(active);
    }
    public void ReceiveActionThenContinueStory(string action, UnityAction ContinueStory)
    {
        if (action == "GetPlayerName")
        {
            GetPlayerName();
        }
    }
    public bool IsInputWindowActivated()
    {
        return UI_Input_Window.IsActivated();
    }
    private void GetPlayerName()
    {
        if (DialogueManager.dialogueIsPlaying) Debug.LogWarning("From InputField there is other using dialogueIsPlaying");
        DialogueManager.dialogueIsPlaying = true;
        DialogueManager.instance.LockCamera();
        DialogueManager.instance.EnablePlayerControll();
        UI_Input_Window.ActivateMenu(
            "เจ้าชื่ออะไร",
            (string inputValue) =>
            {
                if (inputValue != "")
                {
                    DialogueManager.dialogueIsPlaying = false;
                    DialogueManager.instance.UnlockCamera();
                    DialogueManager.instance.DisablePlayerControll();
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

    public void LoadData(GameData data)
    {
        playerName = data.name;
    }

    public void SaveData(GameData data)
    {
        data.name = playerName;
    }
}
