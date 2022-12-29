using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class NPC_Details
{
    public string name;
    public GameObject Object;
}
public class StageHandler : MonoBehaviour
{
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
                break;
            case SceneIndex.CalfordCastle:
                break;
            case SceneIndex.BraewoodForest:
                break;
            case SceneIndex.Cave:
                break;
        }
        // if (sceneIndex == SceneIndex.Rachne)
        // {
        //     AudioManager.instance.Play("forestBackground");
        //     if (DialogueManager.instance.GetVariableState("readOP").ToString().Equals("false"))
        //     {
        //         DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("Opening"));
        //     }
        //     if (!PlayerManager.instance.playerEvents["finishedTutorial"])
        //     {
        //         EventTrigger("SetupForTutorial");
        //     }
        // }
    }
    public void EventTrigger(string eventName)
    {
        switch (activeSceneIndex)
        {
            case (int)SceneIndex.Rachne:
                TutorialEvents(eventName);
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
                AudioManager.instance.Play("forestBackground");
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
                AudioManager.instance.Play("forestBackground");
                switch (previousScene)
                {
                    case (int)SceneIndex.Rachne:
                        player.position = n_rachneGate.position;
                        player.rotation = n_rachneGate.rotation;
                        break;
                }
                break;
        }
        PlayerManager.instance.ChangePlayerLocationToCurrent();
    }

    private void TutorialEvents(string eventName)
    {
        switch (eventName)
        {
            case "SataAppear":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.name == "Sata")
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
                SpawnWebster(1);
                break;
            case "Spawn5Webster":
                SpawnWebster(5);
                break;
            case "SataLeadToTown":
                foreach (NPC_Details npc in NPCs)
                {
                    if (npc.name == "Sata")
                    {
                        npc.Object.GetComponent<NPC>().Goto(t_naverGate);
                        break;
                    }
                }
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
    private void SpawnWebster(int num)
    {
        if (num == 1)
        {
            spawn0.SpawnMonster(0, 1);
        }
        else if (num == 5)
        {
            spawn1.SpawnMonster(0, 5);
        }
    }
}

