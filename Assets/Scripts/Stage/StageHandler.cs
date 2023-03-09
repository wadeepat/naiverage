using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageHandler : MonoBehaviour
{
    [System.Serializable]
    private class NPC_Details
    {
        public NPCIndex idx;
        public string info = "none";
        public GameObject Object;
    }
    [SerializeField] private SceneIndex sceneIndex;
    [SerializeField] private NPC_Details[] NPCs;

    [Header("Rachne")]
    [Header("Gates")]
    [SerializeField] private Transform t_startGate;
    [SerializeField] private Transform t_naverGate;
    [SerializeField] private Transform t_RachneGate;
    [Header("Monster Spawn")]
    [SerializeField] private MonsterSpawn spawn0;
    [SerializeField] private MonsterSpawn spawn1;
    [SerializeField] private MonsterSpawn spawn2;

    [Header("NaverTown")]
    [SerializeField] private Transform n_rachneGate;
    [SerializeField] private Transform n_calfordGate;
    [SerializeField] private Transform n_braewoodGate;
    [SerializeField] private Transform n_mainDoor;
    [SerializeField] private Transform n_mainDoor1;
    [SerializeField] private Transform n_frontOfRanche0;
    [SerializeField] private Transform n_frontOfRanche1;
    [SerializeField] private Transform n_frontOfCastle;
    [SerializeField] private Transform n_oldmanHouse;

    [Header("Calford")]
    [Header("Gates")]
    [SerializeField] private Transform cc_naverGate;

    [Header("Braewood")]
    [Header("Gates")]
    [SerializeField] private Transform b_naverGate;
    [SerializeField] private Transform b_caveGate;

    [Header("Cave")]
    [Header("Gates")]
    [SerializeField] private Transform c_braewoodGate;

    [SerializeField] private Transform c_middle;
    [SerializeField] private Transform c_TrollGate;
    [Header("Field")]
    [Header("Gates")]
    [SerializeField] private Transform exitGate;

    public static StageHandler instance;
    public int activeSceneIndex { get; private set; }
    private string activeSceneName;
    // private 
    private void Awake()
    {
        instance = this;
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        activeSceneName = ((SceneIndex)activeSceneIndex).ToString();
    }
    private void Start()
    {
        switch (sceneIndex)
        {
            case SceneIndex.Rachne:
                AudioManager.instance.Play("forestBackground");
                //TODO if have book in questItem
                if (GameObject.Find("Canvas/Panel").GetComponent<ItemQuests>().ishaveItem(4))
                    GameObject.Find("StageTrack").transform.Find("Book").gameObject.SetActive(false);
                if (QuestLog.GetCompleteQuestById(0) == null)
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(0, "Opening"));
                if (!PlayerManager.playerEvents["finishedTutorial"])
                    EventTrigger("SetupForTutorial");
                if (QuestLog.GetActiveQuestById(29) != null ||
                    QuestLog.GetActiveQuestById(43) != null)
                    t_RachneGate.gameObject.SetActive(true);
                break;
            case SceneIndex.NaverTown:
                AudioManager.instance.Play("naverBackground");
                if (PlayerManager.playerEvents["backToPast"])
                {
                    if (QuestLog.GetActiveQuestById(30) == null
                    && QuestLog.GetCompleteQuestById(30) == null)
                        EventTrigger("ReceiveTheBook");
                    //*side quest:save npc
                    if (QuestLog.GetCompleteQuestById(31) != null &&
                        QuestLog.GetCompleteQuestById(49) == null &&
                        QuestLog.GetActiveQuestById(49) == null)
                        NaverTownEvents("MerchantFriend");
                }
                else
                {
                    if (QuestLog.GetCompleteQuestById(8) == null)
                        EventTrigger("IntroduceAaron");
                    //*side quest:catch chick
                    if (!PlayerManager.playerEvents["chickReject"] &&
                        QuestLog.GetCompleteQuestById(14) != null &&
                        QuestLog.GetCompleteQuestById(47) == null &&
                        QuestLog.GetActiveQuestById(47) == null)
                    {
                        NaverTownEvents("FarmerProblem");
                    }
                    if (QuestLog.GetCompleteQuestById(41) != null &&
                        QuestLog.GetCompleteQuestById(55) == null &&
                        QuestLog.GetCompleteQuestById(57) == null &&
                        QuestLog.GetActiveQuestById(55) == null &&
                        QuestLog.GetActiveQuestById(57) == null)
                        NaverTownEvents("SideC3");
                        
                }
                if (!PlayerManager.instance.mapEnable[SceneIndex.CalfordCastle])
                    n_calfordGate.gameObject.SetActive(false);
                if (!PlayerManager.instance.mapEnable[SceneIndex.BraewoodForest])
                    n_braewoodGate.gameObject.SetActive(false);
                //*checkpoint
                if (QuestLog.GetCompleteQuestById(10) == null)
                    GameObject.Find("Places").transform.Find("Checkpoint").gameObject.SetActive(false);
                break;
            case SceneIndex.CalfordCastle:
                break;
            case SceneIndex.BraewoodForest:
                AudioManager.instance.Play("braewoodBackground");
                if (QuestLog.GetCompleteQuestById(19) == null && QuestLog.GetActiveQuestById(19) == null)
                    b_caveGate.gameObject.SetActive(false);
                if (QuestLog.GetCompleteQuestById(26) != null &&
                        QuestLog.GetCompleteQuestById(51) == null &&
                        QuestLog.GetCompleteQuestById(53) == null &&
                        QuestLog.GetActiveQuestById(51) == null &&
                        QuestLog.GetActiveQuestById(53) == null)
                    BraewoodEvents("GuardHelp");
                break;
            case SceneIndex.Cave:
                AudioManager.instance.Play("caveBackground");
                if (QuestLog.GetCompleteQuestById(20) == null &&
                QuestLog.GetActiveQuestById(20) == null)
                    EventTrigger("FirstMetCain");
                break;
            case SceneIndex.RachneField:
                AudioManager.instance.Play("forestBackground");
                if (QuestLog.GetActiveQuestById(13) != null ||
                    QuestLog.GetActiveQuestById(30) != null)
                    EventTrigger("SpawnRachne");
                break;
            case SceneIndex.TrollField:
                AudioManager.instance.Play("caveBackground");
                if (QuestLog.GetActiveQuestById(24) != null ||
                    QuestLog.GetActiveQuestById(37) != null)
                    SpawnMonsterAt(0, MonsterId.Troll, 1);
                break;
            case SceneIndex.BlackScene:
                AudioManager.instance.Play("endingBackground");
                break;
        }
        QuestLog.DoQuestPrepare(sceneIndex);
    }
    public void EventTrigger(string eventName)
    {
        switch (activeSceneIndex)
        {
            case (int)SceneIndex.Rachne:
                RachneEvents(eventName);
                break;
            case (int)SceneIndex.NaverTown:
                NaverTownEvents(eventName);
                break;
            case (int)SceneIndex.CalfordCastle:
                CalfordEvents(eventName);
                break;
            case (int)SceneIndex.BraewoodForest:
                BraewoodEvents(eventName);
                break;
            case (int)SceneIndex.Cave:
                CaveEvents(eventName);
                break;
            default:
                // Debug.LogWarning($"There is no Event Trigger for sceneIndex: {activeSceneIndex}");
                OtherEvents(eventName);
                break;
        }

    }
    public void MovePlayer(int previousScene)
    {
        // Debug.Log("Previous " + ((SceneIndex)previousScene).ToString());
        Transform player = PlayerManager.instance.player.transform;
        player.gameObject.SetActive(false);
        switch (activeSceneIndex)
        {
            case (int)SceneIndex.Rachne:
                if (previousScene == (int)SceneIndex.Rachne)
                {
                    player.position = t_startGate.position;
                    player.rotation = t_startGate.rotation;
                }
                else if (previousScene == (int)SceneIndex.RachneField)
                {
                    player.position = t_RachneGate.position;
                    player.rotation = t_RachneGate.rotation;
                }
                else
                {
                    player.position = t_naverGate.position;
                    player.rotation = t_naverGate.rotation;
                }
                break;
            case (int)SceneIndex.NaverTown:
                switch (previousScene)
                {
                    case (int)SceneIndex.Rachne:
                        player.position = n_rachneGate.position;
                        player.rotation = n_rachneGate.rotation;
                        break;
                    case (int)SceneIndex.CalfordCastle:
                        player.position = n_calfordGate.position;
                        player.rotation = n_calfordGate.rotation;
                        break;
                    case (int)SceneIndex.BraewoodForest:
                        player.position = n_braewoodGate.position;
                        player.rotation = n_braewoodGate.rotation;
                        break;
                    default:
                        player.position = n_rachneGate.position;
                        player.rotation = n_rachneGate.rotation;
                        break;
                }
                break;
            case (int)SceneIndex.CalfordCastle:
                player.position = cc_naverGate.position;
                player.rotation = cc_naverGate.rotation;
                break;
            case (int)SceneIndex.BraewoodForest:
                switch (previousScene)
                {
                    case (int)SceneIndex.Cave:
                        player.position = b_caveGate.position;
                        player.rotation = b_caveGate.rotation;
                        break;
                    default:
                        player.position = b_naverGate.position;
                        player.rotation = b_naverGate.rotation;
                        break;
                }
                break;
            case (int)SceneIndex.Cave:
                if (previousScene == (int)SceneIndex.TrollField)
                {
                    player.position = c_TrollGate.position;
                    player.rotation = c_TrollGate.rotation;
                }
                else
                {
                    player.position = c_braewoodGate.position;
                    player.rotation = c_braewoodGate.rotation;
                }
                break;
            default:
                if (exitGate)
                {
                    player.position = exitGate.position;
                    player.rotation = exitGate.rotation;
                }
                break;
        }
        player.gameObject.SetActive(true);
        PlayerManager.instance.ChangePlayerLocationToCurrent();
    }
    private void RachneEvents(string eventName)
    {
        switch (eventName)
        {
            case "SataAppear":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.SetActive(true);
                        DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(0, "SataCall"));
                        break;
                    }
                }
                break;
            case "SetupForTutorial":
                GameObject pickupArea = GameObject.Find("StageTrack").transform.Find("PickupArea").gameObject;
                pickupArea.SetActive(true);
                t_naverGate.gameObject.SetActive(false);
                spawn0.isSpawn = false;
                spawn1.isSpawn = false;
                spawn2.isSpawn = false;
                break;
            case "CompletedUsePotion":
                DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(0, "CompletedUsePotion"));
                break;
            case "CompletedTutorial":
                PlayerManager.playerEvents["finishedTutorial"] = true;
                PlayerManager.instance.mapEnable[SceneIndex.NaverTown] = true;
                t_naverGate.gameObject.SetActive(true);
                break;
            case "Spawn1Webster":
                SpawnMonsterAt(0, MonsterId.Webster, 1);
                break;
            case "Spawn5Webster":
                SpawnMonsterAt(1, MonsterId.Webster, 5);
                break;
            case "GoToNaver":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.GetComponent<NPC>().inkJSON = DialogueManager.instance.GetDialogueFile(0, "GoToNaver");
                        break;
                    }
                }
                break;
            case "SataLeadToTown":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.GetComponent<NPC>().Goto(t_naverGate);
                        break;
                    }
                }
                break;
            case "Spawn10Webster":
                SpawnMonsterAt(0, MonsterId.Webster, 5);
                SpawnMonsterAt(1, MonsterId.Webster, 5);
                break;
            case "RachneEntrance":
                t_RachneGate.gameObject.SetActive(true);
                break;
            case "RunChickenRun":
                GameObject.Find("StageTrack").transform.Find("Chicken").gameObject.SetActive(true);
                break;
            case "SaveNPC":
                GameObject.Find("StageTrack").transform.Find("Victim").gameObject.SetActive(true);
                SpawnMonsterToVictim(2, MonsterId.Webster, 1);
                SpawnMonsterToVictim(2, MonsterId.Venom, 2);
                break;
            case "ThanksFromNPC":
                GameObject victim = GameObject.Find("StageTrack").transform.Find("Victim").gameObject;
                victim.SetActive(true);
                victim.GetComponent<CapsuleCollider>().enabled = true;
                victim.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(5, "ThanksFromNPC");
                break;
            case "FightVenom":
                SpawnMonsterAt(0, MonsterId.Venom, 6);
                SpawnMonsterAt(1, MonsterId.Venom, 6);
                break;
            default:
                Debug.LogWarning($"There is no event name: {eventName} in TutorialEvents");
                break;
        }
    }
    private void NaverTownEvents(string eventName)
    {
        switch (eventName)
        {
            case "IntroduceAaron":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.transform.position = n_frontOfRanche1.position;
                        npc.Object.transform.rotation = n_frontOfRanche1.rotation;
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(1, "IntroduceAaron");
                        npc.Object.SetActive(true);
                    }
                    else if (npc.idx == NPCIndex.Aaron)
                    {
                        npc.Object.transform.position = n_frontOfRanche0.position;
                        npc.Object.transform.rotation = n_frontOfRanche0.rotation;
                        npc.Object.SetActive(true);
                    }
                }
                break;
            case "AaronMoveToMainDoor":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Aaron && npc.info == "IntroduceAaron")
                    {
                        npc.Object.GetComponent<NPC>().Goto(n_mainDoor);
                        break;
                    }
                }
                break;
            case "AaronAtMainDoor":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Aaron)
                    {
                        npc.Object.SetActive(false);
                        npc.Object.transform.localPosition = n_mainDoor.position;
                        npc.Object.transform.localRotation = n_mainDoor.rotation;
                        npc.Object.SetActive(true);
                        break;
                    }
                }
                break;
            case "ReceiveTheBook":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.SetActive(false);
                        npc.Object.transform.localPosition = n_frontOfCastle.position;
                        npc.Object.transform.rotation = n_frontOfCastle.rotation;
                        npc.Object.SetActive(true);


                        if (PlayerManager.playerEvents["backToPast"])
                        {
                            PlayerManager.instance.player.SetActive(false);
                            PlayerManager.instance.player.transform.rotation = Quaternion.Euler(0, 5, 0);
                            PlayerManager.instance.player.transform.position = new Vector3(n_frontOfCastle.position.x, n_frontOfCastle.position.y, n_frontOfCastle.position.z - 1);
                            PlayerManager.instance.player.SetActive(true);

                            DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(1, "ReceiveTheBookAgain"));
                        }
                        else
                        {
                            npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(1, "ReceiveTheBook");
                        }
                        break;
                    }
                }
                break;
            case "Checkpoint":
                GameObject.Find("Places").transform.Find("Checkpoint").gameObject.SetActive(true);
                break;
            case "TalkWithMerchant":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Villager && npc.info == "Merchant")
                    {
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(1, "TalkToMerchant");
                        npc.Object.SetActive(true);
                        break;
                    }
                }
                break;
            case "AbelFirstMet":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Abel)
                    {
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().Goto(PlayerManager.instance.player.transform);
                        break;
                    }
                }
                break;
            case "AbelGoToHouse":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Abel)
                    {
                        // Debug.Log("Goooo");
                        npc.Object.GetComponent<NPC>().Goto(n_oldmanHouse);
                        break;
                    }
                }
                break;
            case "AbelAtOldmanHouse":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Abel)
                    {
                        npc.Object.SetActive(false);
                        npc.Object.transform.rotation = n_oldmanHouse.transform.rotation;
                        npc.Object.transform.position = new Vector3(n_oldmanHouse.transform.position.x, n_oldmanHouse.transform.position.y, n_oldmanHouse.transform.position.z - 1);
                        npc.Object.SetActive(true);
                        break;
                    }
                }
                break;
            case "SataAtOldmanHouse":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.SetActive(false);
                        npc.Object.transform.position = n_oldmanHouse.transform.position;
                        npc.Object.transform.rotation = n_oldmanHouse.transform.rotation;
                        npc.Object.SetActive(true);
                        break;
                    }
                }
                break;
            case "HappyFamily":
                EventTrigger("SataAtOldmanHouse");
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "OldmanFamily")
                    {
                        npc.Object.SetActive(true);
                        break;
                    }
                }
                break;
            case "SamuelCall":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Samuel)
                    {
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().Goto(n_oldmanHouse);
                        break;
                    }
                }
                break;
            case "Cain'sHint":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "FemaleVillager")
                    {
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().Goto(n_oldmanHouse);
                        break;
                    }
                }
                break;
            case "Army":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Army")
                    {
                        npc.Object.SetActive(true);
                    }
                    else if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.SetActive(false);
                        npc.Object.transform.position = n_mainDoor1.position;
                        npc.Object.transform.rotation = n_mainDoor1.rotation;
                        npc.Object.SetActive(true);
                    }
                }
                break;
            case "SataAtMainDoor":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.SetActive(false);
                        npc.Object.GetComponent<CapsuleCollider>().enabled = false;
                        npc.Object.transform.position = n_mainDoor1.position;
                        npc.Object.SetActive(true);
                        break;
                    }
                }
                break;
            case "UnlockBraewood":
                if (PlayerManager.playerEvents["backToPast"]) BraewoodEvents("UnlockCave");
                PlayerManager.instance.mapEnable[SceneIndex.BraewoodForest] = true;
                n_braewoodGate.gameObject.SetActive(true);
                break;
            case "UnlockCalford":
                PlayerManager.instance.mapEnable[SceneIndex.CalfordCastle] = true;
                n_calfordGate.gameObject.SetActive(true);
                break;
            case "WelcomeCain":
                NaverTownEvents("AaronAtMainDoor");
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Cain)
                    {
                        npc.Object.SetActive(true);
                        break;
                    }
                }
                break;
            case "CainBack":
                QuestLog.CompleteQuest(Database.questList[27]);
                break;
            case "FarmerProblem":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Farmer)
                    {
                        Debug.Log("herer:" + DialogueManager.instance.GetDialogueFile(6, "FarmerProblem") == null);
                        npc.Object.SetActive(true);
                        // npc.Object.GetComponent<CapsuleCollider>().enabled = true;
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(5, "FarmerProblem");
                        npc.Object.GetComponent<NPC>().isSideQuest = true;
                        break;
                    }
                }
                break;
            case "chickReject":
                PlayerManager.playerEvents["chickReject"] = true;
                break;
            case "MerchantFriend":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Merchant")
                    {
                        npc.Object.GetComponent<CapsuleCollider>().enabled = true;
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(5, "SaveNPC");
                        npc.Object.GetComponent<NPC>().isSideQuest = true;
                        break;
                    }
                }
                break;
            case "SideC3":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Oldman")
                    {
                        // Debug.Log("quest");
                        npc.Object.GetComponent<CapsuleCollider>().enabled = true;
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(5, "SideC3");
                        npc.Object.GetComponent<NPC>().isSideQuest = true;
                        break;
                    }
                }
                break;
            case "ThanksSlide":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Oldman")
                    {
                        npc.Object.GetComponent<CapsuleCollider>().enabled = true;
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(5, "ThanksSlide");
                        npc.Object.GetComponent<NPC>().isSideQuest = false;
                        break;
                    }
                }
                break;
            case "ThanksVenom":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Oldman")
                    {
                        npc.Object.GetComponent<CapsuleCollider>().enabled = true;
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(5, "ThanksVenom");
                        npc.Object.GetComponent<NPC>().isSideQuest = false;
                        break;
                    }
                }
                break;
            default:
                Debug.LogWarning($"There is no event name: {eventName} in NaverTownEvents");
                break;
        }
    }
    private void CalfordEvents(string eventName)
    {
        switch (eventName)
        {
            case "Family":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info != "Soul")
                        npc.Object.SetActive(true);
                }
                break;
            case "TheSoul":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Soul") npc.Object.SetActive(true);
                }
                break;
            case "Slide":
                GameObject.Find("Places").transform.Find("book").gameObject.SetActive(true);
                break;
            default:
                Debug.LogWarning($"There is no event name: {eventName} in CalfordEvents");
                break;
        }
    }
    private void BraewoodEvents(string eventName)
    {
        switch (eventName)
        {
            case "VillagersHint":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Normal")
                        npc.Object.GetComponent<NPC>().inkJSON = DialogueManager.instance.GetDialogueFile(2, "TalkToVillager0");
                    else if (npc.info == "Hint")
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(2, "TalkToVillager1");
                }
                break;
            case "enableGuardTalk":
                QuestLog.CompleteQuest(Database.questList[17]);
                QuestLog.AddQuest(Database.questList[18]);
                break;
            case "GuardHint":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Guard")
                    {
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(2, "AskGuardAboutCain");
                        break;
                    }
                }
                break;
            // case "FindCain":
            //     QuestLog.CompleteQuest(Database.questList[18]);
            //     QuestLog.AddQuest(Database.questList[19]);
            //     break;
            case "UnlockCave":
                PlayerManager.instance.mapEnable[SceneIndex.Cave] = true;
                if (b_caveGate != null) b_caveGate?.gameObject.SetActive(true);
                break;
            case "HelpHisFriend":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Cain)
                    {
                        npc.Object.SetActive(true);
                    }
                    else if (npc.info == "Friend")
                    {
                        npc.Object.SetActive(true);
                    }
                    // DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(2, "PrinceAndVillagers"));
                }
                Debug.Log("HelpFriend");
                break;
            case "FriendLeave":
                Transform place = null;
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Normal")
                    {
                        place = npc.Object.transform;
                        break;
                    }
                }
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Friend")
                    {
                        npc.Object.GetComponent<NPC>().Goto(place);
                        break;
                    }
                }
                break;
            case "TheManIsSaved":
                foreach (NPC_Details npc in NPCs)
                {
                    int n = 0;
                    if (npc.info == "Hurt" || npc.info == "Friend")
                    {

                    }
                    else if (npc.idx == NPCIndex.Cain)
                    {
                        if (PlayerManager.playerEvents["backToPast"])
                            npc.Object.GetComponent<NPC>().inkJSON = DialogueManager.instance.GetDialogueFile(2, "BackToFriendAgain");
                        else
                            npc.Object.GetComponent<NPC>().inkJSON = DialogueManager.instance.GetDialogueFile(2, "BackToFriend");
                    }
                    else continue;
                    npc.Object.SetActive(true);
                    if (++n == 3) break;
                }
                break;
            case "CainGoToNaver":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Cain)
                    {
                        npc.Object.GetComponent<NPC>().Goto(b_naverGate);
                        break;
                    }
                }
                break;
            case "GuardHelp":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Guard")
                    {
                        npc.Object.GetComponent<CapsuleCollider>().enabled = true;
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(5, "GuardHelp");
                        npc.Object.GetComponent<NPC>().isSideQuest = true;
                        break;
                    }
                }
                break;
            case "Flip":
                //setactive obj
                GameObject.Find("Places").transform.Find("picture").gameObject.SetActive(true);
                break;
            case "ThanksSkeletonGuard":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Guard")
                    {
                        npc.Object.GetComponent<CapsuleCollider>().enabled = true;
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(5, "ThanksSkeletonGuard");
                        npc.Object.GetComponent<NPC>().isSideQuest = false;
                        break;
                    }
                }
                break;
            case "ThanksFlipGuard":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.info == "Guard")
                    {
                        npc.Object.GetComponent<CapsuleCollider>().enabled = true;
                        npc.Object.SetActive(true);
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(5, "ThanksFlipGuard");
                        npc.Object.GetComponent<NPC>().isSideQuest = false;
                        break;
                    }
                }
                break;
            default:
                Debug.LogWarning($"There is no event name: {eventName} in BraewoodEvents");
                break;
        }
    }
    private void CaveEvents(string eventName)
    {
        switch (eventName)
        {
            case "CainAtFront":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Cain)
                    {
                        npc.Object.SetActive(true);
                        break;
                    }
                }
                break;
            case "FirstMetCain":
                CaveEvents("CainAtFront");
                if (PlayerManager.playerEvents["backToPast"])
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(2, "FirstMetCainAgain"));
                else
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(2, "FirstMetCain"));
                break;
            case "AggressiveMon":
                if (PlayerManager.playerEvents["backToPast"])
                {
                    // SpawnMonsterAt(0, MonsterId.Bandit, 1);
                    SpawnMonsterAt(1, MonsterId.Bandit, 5);
                }
                else
                {
                    // SpawnMonsterAt(0, MonsterId.Skeleton, 1);
                    SpawnMonsterAt(1, MonsterId.Skeleton, 5);
                }
                break;
            case "LostMan":
                if (PlayerManager.playerEvents["backToPast"])
                {
                    foreach (NPC_Details npc in NPCs)
                    {
                        if (npc.info == "Hurt" || npc.info == "Center1")
                        {
                            npc.Object.SetActive(true);
                        }
                    }
                }
                else
                {
                    foreach (NPC_Details npc in NPCs)
                    {
                        if (npc.info == "Hurt" || npc.info == "Center")
                        {
                            npc.Object.SetActive(true);
                        }
                    }
                }
                break;
            case "FoundTheMan":
                QuestLog.CompleteQuest(Database.questList[23]);
                break;
            case "TrollEntrance":
                c_TrollGate.gameObject.SetActive(true);
                break;
            case "CainAndHurt":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Cain)
                    {
                        npc.Object.SetActive(false);
                        npc.Object.transform.position = c_middle.position;
                        npc.Object.transform.rotation = c_middle.rotation;
                        npc.Object.SetActive(true);
                    }
                    else if (npc.info == "Hurt")
                        npc.Object.SetActive(true);
                }
                break;
            case "FightForGuard":
                SpawnMonsterAt(1, MonsterId.Skeleton, 10);
                break;
            default:
                Debug.LogWarning($"There is no event name: {eventName} in CaveEvents");
                break;
        }
    }
    private void OtherEvents(string eventName)
    {
        switch (eventName)
        {

            case "SpawnRachne":
                SpawnMonsterAt(0, MonsterId.Rachne, 1);
                break;
            case "ExitGate":
                exitGate.gameObject.SetActive(true);
                break;
            case "Commanment":
                foreach (NPC_Details npc in NPCs)
                {
                    npc.Object.SetActive(true);
                    if (npc.idx == NPCIndex.Samuel)
                    {
                        //TODO if have book
                        if (GameObject.Find("Canvas/Panel").GetComponent<ItemQuests>().ishaveItem(4))
                        {
                            npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(4, "TheCommandment");
                        }
                        else
                        {
                            npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(4, "WithoutBook");
                        }
                    }
                }
                OtherEvents("ExitGate");
                break;
            case "Light":
                ActionHandler.instance.MakeFlash();
                break;
            case "BackToMenu":
                SceneLoadingManager.instance.LoadScene(SceneIndex.MainMenu);
                break;
            case "BackToPast":
                PlayerManager.playerEvents["backToPast"] = true;
                PlayerManager.instance.mapEnable[SceneIndex.CalfordCastle] = false;
                PlayerManager.instance.mapEnable[SceneIndex.BraewoodForest] = false;
                PlayerManager.instance.mapEnable[SceneIndex.Cave] = false;
                SceneLoadingManager.instance.LoadScene(SceneIndex.NaverTown);
                break;
            case "FightWithAbel":
                ActionHandler.instance.SetPath(1);
                LockAllMap();
                PlayerManager.instance.playerLocation = SceneIndex.TrollField;
                QuestLog.AddQuest(Database.questList[44]);
                DataPersistenceManager.instance.SaveGame(true);
                SceneLoadingManager.instance.LoadScene(SceneIndex.TrollField);
                break;
            case "FightWithCain":
                ActionHandler.instance.SetPath(2);
                LockAllMap();
                PlayerManager.instance.playerLocation = SceneIndex.TrollField;
                QuestLog.AddQuest(Database.questList[45]);
                DataPersistenceManager.instance.SaveGame(true);
                SceneLoadingManager.instance.LoadScene(SceneIndex.TrollField);
                break;
            case "Abel":
                SpawnMonsterAt(0, MonsterId.Abel, 1);
                break;
            case "Cain":
                SpawnMonsterAt(0, MonsterId.Cain, 1);
                break;
            default:
                Debug.LogWarning($"There is no event name: {eventName} in OtherEvents");
                break;
        }
    }
    private void LockAllMap()
    {
        PlayerManager.instance.mapEnable[SceneIndex.Rachne] = false;
        PlayerManager.instance.mapEnable[SceneIndex.NaverTown] = false;
        PlayerManager.instance.mapEnable[SceneIndex.CalfordCastle] = false;
        PlayerManager.instance.mapEnable[SceneIndex.BraewoodForest] = false;
        PlayerManager.instance.mapEnable[SceneIndex.Cave] = false;
    }
    private void SpawnMonsterAt(int spawnNo, MonsterId monsterIdx, int num)
    {
        if (spawnNo == 0)
        {
            spawn0.SpawnMonster((int)monsterIdx, num, false);
        }
        else if (spawnNo == 1)
        {
            spawn1.SpawnMonster((int)monsterIdx, num, false);
        }
    }
    private void SpawnMonsterToVictim(int spawnNo, MonsterId monsterIdx, int num)
    {
        if (spawnNo == 0)
        {
            spawn0.SpawnMonster((int)monsterIdx, num, true);
        }
        else if (spawnNo == 1)
        {
            spawn1.SpawnMonster((int)monsterIdx, num, true);
        }
        else if (spawnNo == 2)
        {
            spawn2.SpawnMonster((int)monsterIdx, num, true);
        }
    }
}

