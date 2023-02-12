using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectPotion : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    UsePotions usePotions;
    void Start()
    {
        Player = GameObject.Find("Player");
        usePotions = Player.GetComponent<UsePotions>();
    }

    public void PExit(Image slotX){
        slotX.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    public void PEnter(Image slotX){
        slotX.color = new Color(255/255f, 137/255f, 129/255f, 1.0f);
    }
    public void PClick(int id){
        usePotions.UsePotionT(id);
    }

    
}
