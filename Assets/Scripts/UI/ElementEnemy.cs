using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite spriteElement;
    public Image imageElement;
    void ShowElement(ElementType e){
        if(e == ElementType.Fire){
            spriteElement = Resources.Load<Sprite>("f");
        }else if(e == ElementType.Water){
            spriteElement = Resources.Load<Sprite>("wt");
        }else if(e == ElementType.Wind){
            spriteElement = Resources.Load<Sprite>("w");
        }else{
            spriteElement = Resources.Load<Sprite>("phy");
        }
        imageElement.sprite = spriteElement;
    }
    // Update is called once per frame
}
