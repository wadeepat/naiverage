using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SataFirstMetNPC : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    private bool finishedTutorial = false;
    void Start()
    {
        if (finishedTutorial)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        this.finishedTutorial = data.finishedTutorial;
    }
    public void SaveData(GameData data)
    {
        data.finishedTutorial = this.finishedTutorial;
    }
}
