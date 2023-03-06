using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchRotate : MonoBehaviour
{
    void start(){
    }
    void update(){

    }
    public void RotateImage(){
        int ran = Random.Range(0,4);
        this.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, ran*90f);
    }
    public void Click(){
        if(!GameControl.youWin) transform.Rotate(0f,0f,90f);
        this.transform.parent.GetComponent<GameControl>().CheckWin();
    }
    public void AddClick()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }
}
