using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SataFirstMetNPC : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    // private bool sataAskToJoin = false;
    // private bool finishedTutorial = true;
    void Start()
    {
        // Debug.Log("from save is: " + sataAskToJoin +
        // "\nfrom dialogsave is: " + DialogueManager.instance.GetVariableState("sataAskToJoin")
        // );
        // if (finishedTutorial)
        // {
        //     gameObject.SetActive(true);
        // }
        // else
        // {
        //     gameObject.SetActive(false);
        // }
    }

    public void LoadData(GameData data)
    {
        // data.tutorialEvents.TryGetValue("sataAskToJoin", out sataAskToJoin);
        // DialogueManager.instance.GetDialogueVariables().GetGlobalStory().variablesState["sataAskToJoin"] = false;

    }
    public void SaveData(GameData data)
    {
        // if (data.tutorialEvents.ContainsKey("sataAskToJoin"))
        // {
        //     data.tutorialEvents["sataAskToJoin"] = DialogueManager.instance.GetVariableState("sataAskToJoin");
        //     // Debug.Log("sataSave:::: " + data.tutorialEvents["sataAskToJoin"]);
        // }
        // else
        // {
        //     Debug.LogWarning("Can't find sataAskToJoin variable is missing");
        // }
    }
    public void SetNPCActivation(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }
}
