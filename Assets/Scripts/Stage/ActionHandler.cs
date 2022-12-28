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
    // public void AcceptQuest(int id)
    // {
    // switch (id)
    // {
    //     case 0:
    //         ActivateTutorialCard("Walking", true);
    //         QuestLog.AddQuest(new Quest()
    //         {
    //             questId = 0,
    //             questName = "Learn to move",
    //             questDescription = "Move to the area",
    //             MPReward = 0,
    //             SBReward = "",
    //             questCategory = 0,
    //             objective = new Quest.Objective()
    //             {
    //                 objectiveId = 1,
    //                 type = Quest.Objective.Type.interact,
    //                 amount = 1,
    //             },
    //             compleltedAction = () =>
    //             {
    //                 AcceptQuest(1);
    //             },
    //         });
    //         break;
    //     case 1:
    //         ActivateTutorialCard("PickupItems", true);
    //         QuestLog.AddQuest(new Quest()
    //         {
    //             questId = 1,
    //             questName = "Collect Mushroom",
    //             questDescription = "",
    //             MPReward = 0,
    //             SBReward = "",
    //             questCategory = 0,
    //             objective = new Quest.Objective()
    //             {
    //                 objectiveId = 1,
    //                 type = Quest.Objective.Type.collect,
    //                 amount = 1,
    //             },
    //             compleltedAction = () =>
    //             {
    //                 ActivateTutorialCard("PickupItems", false);
    //                 AcceptQuest(2);
    //             }
    //         });
    //         break;
    //     case 2:
    //         ActivateTutorialCard("CraftPotion", true);
    //         QuestLog.AddQuest(new Quest()
    //         {
    //             questId = 2,
    //             questName = "Craft Potion",
    //             questDescription = "",
    //             MPReward = 0,
    //             SBReward = "",
    //             questCategory = 0,
    //             objective = new Quest.Objective()
    //             {
    //                 objectiveId = 1,
    //                 type = Quest.Objective.Type.interact,
    //                 amount = 1,
    //             },
    //             updateAction = () =>
    //             {
    //                 if (CanvasManager.instance.GetCanvasObject("Panel").transform.Find("Character panel").gameObject.activeSelf)
    //                 {
    //                     QuestLog.CompleteQuest(QuestLog.GetQuestById(2));
    //                 }
    //             },
    //             compleltedAction = () =>
    //             {
    //                 ActivateTutorialCard("CraftPotion", false);
    //                 AcceptQuest(3);
    //             },
    //         });
    //         break;
    //     case 3:
    //         ActivateTutorialCard("UsePotion", true);
    //         QuestLog.AddQuest(new Quest()
    //         {
    //             questId = 3,
    //             questName = "Use Potion",
    //             questDescription = "Use Health Potion",
    //             MPReward = 0,
    //             SBReward = "",
    //             questCategory = 0,
    //             objective = new Quest.Objective()
    //             {
    //                 objectiveId = 1,
    //                 type = Quest.Objective.Type.interact,
    //                 amount = 1,
    //             },
    //             compleltedAction = () =>
    //             {
    //                 ActionHandler.instance.ActivateTutorialCard("UsePotion", false);
    //                 DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("CompletedUsePotion"));
    //             },
    //         });
    //         break;
    //     case 4:
    //         ActivateTutorialCard("NormalAttack", true);
    //         QuestLog.AddQuest(new Quest()
    //         {
    //             questId = 4,
    //             questName = "Fight to survive",
    //             questDescription = "Kill 1 Webster",
    //             MPReward = 0,
    //             SBReward = "",
    //             questCategory = 0,
    //             objective = new Quest.Objective()
    //             {
    //                 objectiveId = 1,
    //                 type = Quest.Objective.Type.kill,
    //                 amount = 1,
    //             },
    //             compleltedAction = () =>
    //             {
    //                 ActivateTutorialCard("NormalAttack", false);
    //                 DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("CompletedUsePotion"));
    //                 StageHandler.instance.EventTrigger("SataAppear");
    //             },
    //         });
    //         break;
    //     case 5:
    //         ActivateTutorialCard("Skill", true);
    //         StageHandler.instance.SpawnWebster(5);
    //         QuestLog.AddQuest(new Quest()
    //         {
    //             questId = 5,
    //             questName = "Help Sata from the punishment",
    //             questDescription = "Kill Webster to receive 5 .....",
    //             MPReward = 1000,
    //             SBReward = "",
    //             questCategory = 0,
    //             objective = new Quest.Objective()
    //             {
    //                 objectiveId = 1,
    //                 type = Quest.Objective.Type.kill,
    //                 amount = 5,
    //             },
    //             compleltedAction = () =>
    //             {
    //                 ActivateTutorialCard("Skill", false);
    //                 StageHandler.instance.EventTrigger("CompletedTutorial");
    //                 // DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("CompletedUsePotion"));
    //                 // StageHandler.instance.EventTrigger("SataAppear");
    //             },
    //         });
    //         break;
    // }
    // }
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
        // DialogueManager.instance.dialogueVariables.SetVariableState("name", playerName);
    }

    public void SaveData(GameData data)
    {
        data.name = playerName;
    }
}
