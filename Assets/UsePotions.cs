using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotions : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject Player;

    Potions protions;
    PlayerStatus player;
    // Start is called before the first frame update
    void Start()
    {
        protions = Panel.GetComponent<Potions>();
        player = Player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        bool r = Input.GetKeyDown("r");
        if(r){
           UsePotionT();
        }
    }

    void UsePotionT(){
        if(protions.slotP[0] != -1){
            if(protions.yourPotions[protions.slotP[0]].id == 1){
                protions.slotStack[protions.slotP[0]] -= 1;
                PlayerStatus.healthHP(20);
                if(protions.slotStack[protions.slotP[0]] == 0){
                    protions.yourPotions[protions.slotP[0]] = Database.potionList[0];
                    protions.slotP[0] = -1;
                    protions.slotStack[protions.slotP[0]] = 0;
                    protions.slot[0].sprite = protions.slotSprite[0];
                }
            }
        }
        
    }
}
