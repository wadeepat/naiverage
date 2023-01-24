using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotions : MonoBehaviour
{
    private GameObject Player, Panel, SlotPotion;
    Potions protions;
    PlayerStatus player;

    //TODO implement for other potions
    public delegate void OnUsePotion();
    public static OnUsePotion onUsePotion;
    void Start()
    {
        Panel = GameObject.Find("Canvas/Panel");
        Player = GameObject.Find("Player");
        SlotPotion = GameObject.Find("Canvas/Panel/Slot potion");
        protions = Panel.GetComponent<Potions>();
        player = Player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (InputManager.instance.GetUsePotionPressed())
        {
            UsePotionT(0);
        }
        else  if (InputManager.instance.GetSelectingPotion())
        {
            SelectPotion();
        }


    }

    void UsePotionT(int slot)
    {
        if (protions.slotP[slot] != -1 &&protions.slotP[slot] != 0)
        {
            int skillId = protions.yourPotions[protions.slotP[slot]].id;
            switch(skillId){
                case 1:
                    PlayerStatus.HealthHP(20);
                    break;
                case 2:
                    PlayerStatus.GetMP(20);
                    break;
                case 3:
                    LaunchProjectile.FlaskOfPoison();
                    break;
                case 4:
                    LaunchProjectile.FlaskOfIllusion();
                    break;
                case 5:
                    GetComponent<PlayerStatus>().PhialOfFreedom();
                    break;
                case 6:
                    PlayerStatus.HealthHP(50);
                    break;
                case 7:
                    PlayerStatus.GetMP(50);
                    break;
                case 8:
                    LaunchProjectile.FlaskOfAgony();
                    break;
                case 9:
                    GetComponent<PlayerStatus>().ElixirOfRage();
                    break;
                case 10:
                    PlayerStatus.HealthHP(100);
                    break;
                case 11:
                    PlayerStatus.GetMP(100);
                    break;
                case 12:
                    PlayerStatus.MaxHPnMP();
                    break;
            }
            
            protions.slotStack[protions.slotP[slot]] -= 1;
            if (protions.slotStack[protions.slotP[slot]] == 0)
            {
                protions.yourPotions[protions.slotP[slot]] = Database.potionList[0];
                protions.slotStack[protions.slotP[slot]] = 0;
                protions.slotP[slot] = -1;
                protions.slot[slot].sprite = protions.slotSprite[0];
            }
        }
        onUsePotion?.Invoke();
    }

    void SelectPotion()
    {
        Debug.Log("select");
    }

}
