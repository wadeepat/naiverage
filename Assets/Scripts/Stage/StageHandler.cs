using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class NPC
{
    public string name;
    public GameObject Object;
}
public class StageHandler : MonoBehaviour
{
    [SerializeField] private SceneIndex sceneIndex;

    // [Header("NPC")]
    [SerializeField] private NPC[] NPCs;
    // [SerializeField] private LightGuide lightGuide;

    [Header("Tutorial")]
    [Header("Gates")]
    [SerializeField] private Transform t_startGate;
    [SerializeField] private Transform t_naverGate;
    [Header("Monster")]
    [SerializeField] private GameObject webster;
    [SerializeField] private GameObject websterFarm;
    // [SerializeField] private Gamespawn1Webster;
    // [SerializeField] private Transform spawn5Webster;


    [Header("NaverTown")]
    [SerializeField] private Transform n_rachneGate;
    [SerializeField] private Transform n_calfordGate;
    [SerializeField] private Transform n_braewoodGate;
    [Header("Cave")]
    [SerializeField] private Transform c_naverGate;

    // [Header("Places")]
    // [SerializeField] private Transform picupItems;
    public static StageHandler instance;
    public int activeSceneIndex { get; private set; }
    private string activeSceneName;
    // private 
    private void Awake()
    {
        instance = this;
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        activeSceneName = ((SceneIndex)activeSceneIndex).ToString();
        // PlayerManager.instance.ChangePlayerLocation(((SceneIndex)activeSceneIndex).ToString());
    }
    private void Start()
    {
        if (sceneIndex == SceneIndex.Tutorial)
        {
            if (!PlayerManager.instance.playerEvents["finishedTutorial"])
            {
                EventTrigger("SetupForTutorial");
            }
        }
    }
    public void EventTrigger(string eventName)
    {
        // Debug.LogWarning("Event trigger: " + eventName);
        switch (activeSceneIndex)
        {
            case (int)SceneIndex.Tutorial:
                switch (eventName)
                {
                    case "SataAppear":
                        foreach (NPC npc in NPCs)
                        {
                            // Debug.LogWarning("Event trigger: " + npc.name);
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
                }
                break;
        }

    }
    public void MovePlayer(int previousScene)
    {
        Transform player = PlayerManager.instance.player.transform;
        switch (activeSceneIndex)
        {
            case (int)SceneIndex.Tutorial:
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
                    case (int)SceneIndex.Tutorial:
                        player.position = n_rachneGate.position;
                        player.rotation = n_rachneGate.rotation;
                        break;
                }
                break;
        }
    }
    //For tutorialScene
    public void SpawnWebster(int num)
    {
        //TODO
        if (num == 1)
        {
            webster.SetActive(true);
        }
        else if (num == 5)
        {
            websterFarm.SetActive(true);
        }
    }

}
