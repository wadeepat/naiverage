using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageHandler : MonoBehaviour
{
    [SerializeField] private SceneIndex sceneIndex;
    [Header("Tutorial")]
    [SerializeField] private Transform t_startGate;
    [SerializeField] private Transform t_naverGate;
    [Header("NaverTown")]
    [SerializeField] private Transform n_rachneGate;
    [SerializeField] private Transform n_calfordGate;
    [SerializeField] private Transform n_braewoodGate;
    [Header("Cave")]
    [SerializeField] private Transform c_naverGate;

    public static StageHandler instance;
    private int activeSceneIndex;
    private string activeSceneName;

    private void Awake()
    {
        instance = this;
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        activeSceneName = ((SceneIndex)activeSceneIndex).ToString();
        // PlayerManager.instance.ChangePlayerLocation(((SceneIndex)activeSceneIndex).ToString());
    }
    // private void Start()
    // {
    //     // PickupArea.isTrigger
    //     // PickupArea.private void OnTriggerEnter(Collider other)
    //     // {

    //     // }
    //     map.
    // }

    // private void Update()
    // {
    //     if (PickupArea.isTrigger)
    //     {
    //         ActionHandler.instance.ActivateTutorialCard("ttrWalking", false);
    //     }
    // }

    public void MovePlayer(int previousScene, Transform player)
    {
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
        // player.LookAt(Vector3.zero);
    }
}
