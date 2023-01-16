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
                if (DialogueManager.instance.GetVariableState("readOP").ToString().Equals("false"))
                {
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("Opening"));
                }
                if (!PlayerManager.instance.playerEvents["finishedTutorial"])
                {
                    EventTrigger("SetupForTutorial");
                }
                break;
            case SceneIndex.NaverTown:
                AudioManager.instance.Play("naverBackground");
                if (!PlayerManager.instance.playerEvents["metAaron"])
                    EventTrigger("IntroduceAaron");
                // QuestLog.AddQuest(Database.questList[9]);
                // EventTrigger("AaronQuest");
                break;
            case SceneIndex.CalfordCastle:
                break;
            case SceneIndex.BraewoodForest:
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
                Debug.LogWarning($"There is no Event Trigger for sceneIndex: {activeSceneIndex}");
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
                    case (int)SceneIndex.NaverTown:
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
                }
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
                        DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("SataCall"));
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
                DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("CompletedUsePotion"));
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
                        npc.Object.transform.position = n_frontOfRanche1.position;
                        npc.Object.transform.rotation = n_frontOfRanche1.rotation;
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetChapter1Files("IntroduceAaron");
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
            case "AaronQuest":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.idx == NPCIndex.Aaron)
                    {
                        npc.Object.transform.position = n_mainDoor.position;
                        npc.Object.transform.rotation = n_mainDoor.rotation;
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
                        npc.Object.transform.position = n_frontOfCastle.position;
                        npc.Object.transform.rotation = n_frontOfCastle.rotation;
                        npc.Object.GetComponent<NPC>().quest = DialogueManager.instance.GetChapter1Files("ReceiveTheBook");
                        npc.Object.SetActive(true);
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

