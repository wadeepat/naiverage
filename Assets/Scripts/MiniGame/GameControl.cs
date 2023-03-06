using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private static Transform[] pictures;
    // private GameObject winText;
    public static bool youWin;
    static StarterAssetsInputs assetsInputs;
    void Awake()
    {
        pictures = new Transform[15];
        youWin = false;
        assetsInputs = PlayerManager.instance.player.GetComponent<StarterAssetsInputs>();
        PlayerManager.instance.player.GetComponent<PlayerAttackController>().attackAble = false;
        assetsInputs.cursorInputForLook = false;
        assetsInputs.cursorLocked = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        for(int i=0; i < 15; i++){
            pictures[i] = this.transform.Find("castle ("+i+")");
            pictures[i].GetComponent<TouchRotate>().RotateImage();
            pictures[i].GetComponent<TouchRotate>().AddClick();
        }
    }

    public void Win(){
        Destroy(this);
    }
    // Update is called once per frame
    public void CheckWin(){
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
            assetsInputs = PlayerManager.instance.player.GetComponent<StarterAssetsInputs>();
            PlayerManager.instance.player.GetComponent<PlayerAttackController>().attackAble = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            assetsInputs.cursorInputForLook = true;
            assetsInputs.cursorLocked = true;
            GameObject.Find("Player").transform.GetComponent<ItemPickUp>().DestroyThisOj();
        }
    }
}
