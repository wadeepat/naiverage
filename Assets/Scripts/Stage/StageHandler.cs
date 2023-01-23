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

    [Header("NaverTown")]
    [SerializeField] private Transform n_rachneGate;
    [SerializeField] private Transform n_calfordGate;
    [SerializeField] private Transform n_braewoodGate;
    [SerializeField] private Transform n_mainDoor;
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
                // if (DialogueManager.instance.GetVariableState("readOP").ToString().Equals("false"))
                // {
                //     DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(0, "Opening"));
                // }
                if (QuestLog.GetCompleteQuestById(0) == null)
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(0, "Opening"));
                if (!PlayerManager.instance.playerEvents["finishedTutorial"])
                {
                    EventTrigger("SetupForTutorial");
                }
                break;
            case SceneIndex.NaverTown:
                AudioManager.instance.Play("naverBackground");
                if (QuestLog.GetCompleteQuestById(8) == null)
                    EventTrigger("IntroduceAaron");
                if (QuestLog.GetCompleteQuestById(16) == null && QuestLog.GetActiveQuestById(16) == null)
                    n_braewoodGate.gameObject.SetActive(false);
                // QuestLog.AddQuest(Database.questList[9]);
                // EventTrigger("AaronQuest");
                break;
            case SceneIndex.CalfordCastle:
                break;
            case SceneIndex.BraewoodForest:
                if (QuestLog.GetCompleteQuestById(17) == null)
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(2, "TalkWithGuard"));
                if (QuestLog.GetCompleteQuestById(19) == null && QuestLog.GetActiveQuestById(19) == null)
                    b_caveGate.gameObject.SetActive(false);
                break;
            case SceneIndex.Cave:
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
        switch (activeSceneIndex)
        {
            case (int)SceneIndex.Rachne:
                if (previousScene == (int)SceneIndex.NaverTown)
                {
                    player.position = t_naverGate.position;
                    player.rotation = t_naverGate.rotation;
                }
                else
                {
                    player.position = t_startGate.position;
                    player.rotation = t_startGate.rotation;
                }
                break;
            case (int)SceneIndex.NaverTown:
                switch (previousScene)
                {
                    case (int)SceneIndex.Rachne:
                        player.position = n_rachneGate.position;
                        player.rotation = n_rachneGate.rotation;
                        break;
                    // case (int)SceneIndex.NaverTown:
                    //     player.position = n_rachneGate.position;
                    //     player.rotation = n_rachneGate.rotation;
                    //     break;
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
                player.position = c_braewoodGate.position;
                player.rotation = c_braewoodGate.rotation;
                break;
        }
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
                break;
            case "CompletedUsePotion":
                DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(0, "CompletedUsePotion"));
                break;
            case "CompletedTutorial":
                PlayerManager.instance.playerEvents["finishedTutorial"] = true;
                PlayerManager.instance.mapEnable[SceneIndex.NaverTown] = true;
                t_naverGate.gameObject.SetActive(true);
                break;
            case "Spawn1Webster":
                SpawnMonsterAt(0, MonsterId.Webster, 1);
                break;
            case "Spawn5Webster":
                SpawnMonsterAt(1, MonsterId.Webster, 5);
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
            default:
                Debug.LogWarning($"There is no event name: {eventName} in TutorialEvents");
                break;
        }
    }
    private void NaverTownEvents(string eventName)
    {
        //TODO implement naver events
        switch (eventName)
        {
            case "IntroduceAaron":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.transform.position = n_frontOfRanche1.localToWorldMatrix.GetPosition();
                        npc.Object.transform.rotation = n_frontOfRanche1.localToWorldMatrix.rotation;
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(1, "IntroduceAaron");
                        npc.Object.SetActive(true);
                    }
                    else if (npc.idx == NPCIndex.Aaron)
                    {
                        npc.Object.transform.position = n_frontOfRanche0.localToWorldMatrix.GetPosition();
                        npc.Object.transform.rotation = n_frontOfRanche0.localToWorldMatrix.rotation;
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
                        npc.Object.transform.position = n_mainDoor.localToWorldMatrix.GetPosition();
                        npc.Object.transform.rotation = n_mainDoor.localToWorldMatrix.rotation;
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
                        npc.Object.transform.position = n_frontOfCastle.localToWorldMatrix.GetPosition();
                        npc.Object.transform.rotation = n_frontOfCastle.localToWorldMatrix.rotation;
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetDialogueFile(1, "ReceiveTheBook");
                        npc.Object.SetActive(true);
                        break;
                    }
                }
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
            case "SataAtOldmanHouse":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Sata)
                    {
                        npc.Object.SetActive(true);
                        npc.Object.gameObject.transform.position = n_oldmanHouse.transform.localToWorldMatrix.GetPosition();
                        npc.Object.gameObject.transform.rotation = n_oldmanHouse.transform.localToWorldMatrix.rotation;
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
            case "Cain'sHint":
                // Transform oldmanPosition = new Transform();

                // foreach (NPC_Details npc in NPCs)
                // {
                //     if (npc.info == "Oldman")
                //     {
                //         oldmanPosition = npc.Object.transform;
                //         break;
                //     }
                // }
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
            case "UnlockBraewood":
                PlayerManager.instance.mapEnable[SceneIndex.BraewoodForest] = true;
                n_braewoodGate.gameObject.SetActive(true);
                break;
            default:
                Debug.LogWarning($"There is no event name: {eventName} in NaverTownEvents");
                break;
        }
    }
    private void CalfordEvents(string eventName)
    {
        //TODO implement calford events
        switch (eventName)
        {
            default:
                Debug.LogWarning($"There is no event name: {eventName} in CalfordEvents");
                break;
        }
    }
    private void BraewoodEvents(string eventName)
    {
        //TODO implement braewood events
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
            case "FindCain":
                QuestLog.CompleteQuest(Database.questList[18]);
                QuestLog.AddQuest(Database.questList[19]);
                break;
            case "UnlockCave":
                PlayerManager.instance.mapEnable[SceneIndex.Cave] = true;
                c_braewoodGate.gameObject.SetActive(true);
                break;
            default:
                Debug.LogWarning($"There is no event name: {eventName} in BraewoodEvents");
                break;
        }
    }
    private void CaveEvents(string eventName)
    {
        //TODO implement cave events
        switch (eventName)
        {
            default:
                Debug.LogWarning($"There is no event name: {eventName} in CaveEvents");
                break;
        }
    }
    private void OtherEvents(string eventName)
    {
        switch (eventName)
        {
            case "ExitGate":
                exitGate.gameObject.SetActive(true);
                break;
            default:
                Debug.LogWarning($"There is no event name: {eventName} in OtherEvents");
                break;
        }
    }
    //private for tutorialScene
    private void SpawnMonsterAt(int spawnNo, MonsterId monsterIdx, int num)
    {
        if (spawnNo == 0)
        {
            spawn0.SpawnMonster((int)monsterIdx, num);
        }
        else if (spawnNo == 1)
        {
            spawn1.SpawnMonster((int)monsterIdx, num);
        }
    }
}

