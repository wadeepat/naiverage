using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public bool finishedTutorial;
    public Vector3 playerPosition;
    //if want to use dictionary use SeriablizableDictionary instead
    public GameData()
    {
        this.finishedTutorial = false;
        playerPosition = Vector3.zero;
    }
}
