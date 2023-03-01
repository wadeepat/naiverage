using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private static Transform[] pictures;
    // private GameObject winText;
    public static bool youWin;
    
    void Awake()
    {
        pictures = new Transform[15];
        // winText.SetActive(false);
        youWin = false;
        for(int i=0; i < 15; i++){
            pictures[i] = this.transform.Find("castle ("+i+")");
            pictures[i].GetComponent<TouchRotate>().RotateImage();
            pictures[i].GetComponent<TouchRotate>().AddClick();

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public static void CheckWin(){
        Debug.Log(pictures[0].rotation.z);
        Debug.Log(pictures[1].rotation.z);
        Debug.Log(pictures[2].rotation.z);
        if( pictures[0].rotation.z <= 0.1f &&
            pictures[1].rotation.z <= 0.1f &&
            pictures[2].rotation.z <= 0.1f &&
            pictures[3].rotation.z <= 0.1f &&
            pictures[4].rotation.z <= 0.1f &&
            pictures[5].rotation.z <= 0.1f &&
            pictures[6].rotation.z <= 0.1f &&
            pictures[7].rotation.z <= 0.1f &&
            pictures[8].rotation.z <= 0.1f &&
            pictures[9].rotation.z <= 0.1f &&
            pictures[10].rotation.z <= 0.1f &&
            pictures[11].rotation.z <= 0.1f &&
            pictures[12].rotation.z <= 0.1f &&
            pictures[13].rotation.z <= 0.1f &&
            pictures[14].rotation.z <= 0.1f){
            youWin = true;
            Debug.Log("win");
        }
    }
}
