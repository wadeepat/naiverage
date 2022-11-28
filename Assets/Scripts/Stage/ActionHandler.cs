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
    [SerializeField] private InputTextUI UI_Input_Window;
    [SerializeField] private GameObject TutorialGuidingObject;
    [Header("INK Files")]
    [SerializeField] private TextAsset SataKnowPlayerNameJSON;
    public string playerName { get; private set; }
    private GameObject[] tutorialGuidingCards;
    public static ActionHandler instance;
    private void Awake()
    {
        instance = this;
    }
    public void ActivateTutorialCard(string cardName, bool active)
    {
        Debug.Log("Card " + cardName);
        TutorialGuidingObject.transform.Find(cardName).gameObject.SetActive(active);
    }
    public void ReceiveActionThenContinueStory(string action, UnityAction ContinueStory)
    {
        if (action.Contains("ttr"))
        {
            action = action.Remove(0, 3);
            ActivateTutorialCard(action, true);
        }
        else if (action == "GetPlayerName")
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
                    // Debug.Log("name = " + playerName);
                    // if (continueStory != null) continueStory();
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
        // DialogueManager.instance.dialogueVariables.SetVariableState("name", playerName);
    }

    public void SaveData(GameData data)
    {
        data.name = playerName;
    }
}
